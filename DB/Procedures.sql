ALTER SESSION SET "_ORACLE_SCRIPT" = TRUE;

-------------------------REGISTER_USER-------------------------

CREATE OR REPLACE PROCEDURE register_user
    (p_user_login IN user_table.user_login%TYPE,
    p_user_password IN user_table.user_password%TYPE,
    p_user_name IN user_table.user_name%TYPE,
    p_user_surname IN user_table.user_surname%TYPE)
IS
    cnt NUMBER;
BEGIN
    SELECT COUNT(*) INTO cnt FROM user_table WHERE UPPER(user_login) = UPPER(p_user_login);
    IF (cnt = 0) THEN
        INSERT INTO user_table(user_login, user_password, user_name, user_surname, user_role) VALUES(UPPER(p_user_login), encryption_password(UPPER(p_user_password)), UPPER(p_user_name), UPPER(p_user_surname), 1);
        COMMIT;
    ELSE
        RAISE_APPLICATION_ERROR(-20001, 'This user login using in system');
    END IF;
END register_user;

-------------------------LOG_IN_USER-------------------------

CREATE OR REPLACE PROCEDURE log_in_user
    (p_user_login IN user_table.user_login%TYPE,
    p_user_password IN user_table.user_password%TYPE,
    o_user_login OUT user_table.user_login%TYPE,
    o_user_role OUT role_table.role_name%TYPE)
IS
    CURSOR user_cursor IS SELECT user_login FROM user_table WHERE UPPER(user_login) = UPPER(p_user_login) AND user_password = encryption_password(UPPER(p_user_password));
BEGIN
    OPEN user_cursor;
    FETCH user_cursor INTO o_user_login;
    IF user_cursor%NOTFOUND THEN
    RAISE_APPLICATION_ERROR(-20002, 'Login/Password error');
    END IF;
    CLOSE user_cursor;
    check_role(o_user_login, o_user_role);
END log_in_user;

-------------------------SEARCH_USER-------------------------

CREATE OR REPLACE PROCEDURE search_user
    (p_user_login IN user_table.user_login%TYPE,
    o_user_login OUT user_table.user_login%TYPE,
    o_user_password OUT user_table.user_password%TYPE,
    o_user_name OUT user_table.user_name%TYPE,
    o_user_surname OUT user_table.user_surname%TYPE)
IS
    CURSOR user_cursor IS SELECT user_login, decryption_password(user_password), user_name, user_surname FROM user_table WHERE UPPER(user_login) = UPPER(p_user_login);
BEGIN
    OPEN user_cursor;
    FETCH user_cursor INTO o_user_login, o_user_password, o_user_name, o_user_surname;
    IF user_cursor%NOTFOUND THEN
    RAISE_APPLICATION_ERROR(-20003, 'User is not found');
    END IF;
    CLOSE user_cursor;
END search_user;

-------------------------UPDATE_USER_LOGIN-------------------------

CREATE OR REPLACE PROCEDURE update_user_login
    (p_user_login IN user_table.user_login%TYPE,
    p_new_user_login IN user_table.user_login%TYPE)
IS
    cnt NUMBER;
BEGIN
    SELECT COUNT(*) INTO cnt FROM user_table WHERE UPPER(user_login) = UPPER(p_user_login);
    IF (cnt != 0) THEN
        SELECT COUNT(*) INTO cnt FROM user_table WHERE UPPER(user_login) = UPPER(p_new_user_login);
        IF (cnt = 0) THEN
            UPDATE user_table SET user_login = UPPER(p_new_user_login) WHERE UPPER(user_login) = UPPER(p_user_login);
            COMMIT;
        ELSE
            RAISE_APPLICATION_ERROR(-20001, 'This user login using in system');
        END IF;
    ELSE
        RAISE_APPLICATION_ERROR(-20003, 'User is not found');
    END IF;
END update_user_login;

-------------------------UPDATE_USER_PASSWORD-------------------------

CREATE OR REPLACE PROCEDURE update_user_password
    (p_user_login IN user_table.user_login%TYPE,
    p_new_user_password IN user_table.user_password%TYPE)
IS
    cnt NUMBER;
BEGIN
    SELECT COUNT(*) INTO cnt FROM user_table WHERE UPPER(user_login) = UPPER(p_user_login);
    IF (cnt != 0) THEN
        UPDATE user_table SET user_password = encryption_password(UPPER(p_new_user_password)) WHERE UPPER(user_login) = UPPER(p_user_login);
        COMMIT;
    ELSE
        RAISE_APPLICATION_ERROR(-20003, 'User is not found');
    END IF;
END update_user_password;

-------------------------UPDATE_USER_NAME-------------------------

CREATE OR REPLACE PROCEDURE update_user_name
    (p_user_login IN user_table.user_login%TYPE,
    p_new_user_name IN user_table.user_name%TYPE)
IS
    cnt NUMBER;
BEGIN
    SELECT COUNT(*) INTO cnt FROM user_table WHERE UPPER(user_login) = UPPER(p_user_login);
    IF (cnt != 0) THEN
        UPDATE user_table SET user_name = UPPER(p_new_user_name) WHERE UPPER(user_login) = UPPER(p_user_login);
        COMMIT;
    ELSE
        RAISE_APPLICATION_ERROR(-20003, 'User is not found');
    END IF;
END update_user_name;

-------------------------UPDATE_USER_SURNAME-------------------------

CREATE OR REPLACE PROCEDURE update_user_surname
    (p_user_login IN user_table.user_login%TYPE,
    p_new_user_surname IN user_table.user_surname%TYPE)
IS
    cnt NUMBER;
BEGIN
    SELECT COUNT(*) INTO cnt FROM user_table WHERE UPPER(user_login) = UPPER(p_user_login);
    IF (cnt != 0) THEN
        UPDATE user_table SET user_surname = UPPER(p_new_user_surname) WHERE UPPER(user_login) = UPPER(p_user_login);
        COMMIT;
    ELSE
        RAISE_APPLICATION_ERROR(-20003, 'User is not found');
    END IF;
END update_user_surname;

-------------------------DELETE_USER-------------------------

CREATE OR REPLACE PROCEDURE delete_user
    (p_user_login IN user_table.user_login%TYPE)
IS
    cnt NUMBER;
    usr_id user_table.user_id%TYPE;
BEGIN
    SELECT COUNT(*) INTO cnt FROM user_table WHERE UPPER(user_login) = UPPER(p_user_login);
    IF (cnt != 0) THEN
        SELECT user_id INTO usr_id FROM user_table WHERE UPPER(user_login) = UPPER(p_user_login);
        GAMEDBADMIN.delete_character_by_user(usr_id);
        DELETE FROM user_table WHERE UPPER(user_table.user_login) = UPPER(p_user_login);
        COMMIT;
    ELSE
        RAISE_APPLICATION_ERROR(-20003, 'User is not found');
    END IF;
END delete_user;

-------------------------ENCRYPTION_USER-------------------------

CREATE OR REPLACE FUNCTION encryption_password
    (p_user_password IN user_table.user_password%TYPE)
    RETURN user_table.user_password%TYPE
IS
    l_key VARCHAR2(2000) := '1412199916052000';
    l_in_val VARCHAR2(2000) := p_user_password;
    l_mod NUMBER := DBMS_CRYPTO.encrypt_aes128 + DBMS_CRYPTO.chain_cbc + DBMS_CRYPTO.pad_pkcs5;
    l_enc RAW(2000);
BEGIN
    l_enc := DBMS_CRYPTO.encrypt(utl_i18n.string_to_raw(l_in_val, 'AL32UTF8'), l_mod, utl_i18n.string_to_raw(l_key, 'AL32UTF8'));
RETURN RAWTOHEX(l_enc);
END encryption_password;

-------------------------DECRYPTION_USER-------------------------

CREATE OR REPLACE FUNCTION decryption_password
    (p_user_password IN user_table.user_password%TYPE)
    RETURN user_table.user_password%TYPE
IS
    l_key VARCHAR2(2000) := '1412199916052000';
    l_in_val RAW(2000) := HEXTORAW(p_user_password);
    l_mod NUMBER := DBMS_CRYPTO.encrypt_aes128 + DBMS_CRYPTO.chain_cbc + DBMS_CRYPTO.pad_pkcs5;
    l_dec RAW(2000);
BEGIN
    l_dec := DBMS_CRYPTO.decrypt(l_in_val, l_mod, utl_i18n.string_to_raw(l_key, 'AL32UTF8'));
RETURN utl_i18n.raw_to_char(l_dec);
END decryption_password;

-------------------------CHECK_ROLE-------------------------

CREATE OR REPLACE PROCEDURE check_role
    (p_user_login IN user_table.user_login%TYPE,
    o_user_role OUT role_table.role_name%TYPE)
IS
    CURSOR role_cursor IS SELECT role_name FROM user_role_view WHERE UPPER(user_login) = UPPER(p_user_login);
BEGIN
    OPEN role_cursor;
    FETCH role_cursor INTO o_user_role;
    IF role_cursor%NOTFOUND THEN
    RAISE_APPLICATION_ERROR(-20004, 'Role error');
    END IF;
    CLOSE role_cursor;
END check_role;

-------------------------CREATE_CHARACTER-------------------------

CREATE OR REPLACE PROCEDURE create_character
    (p_user_login IN user_table.user_login%TYPE,
    p_character_name IN character_table.character_name%TYPE,
    p_race_name IN race_table.race_name%TYPE,
    p_class_name IN class_table.class_name%TYPE)
IS
    user_id user_table.user_id%TYPE;
    race_id race_table.race_id%TYPE;
    class_id class_table.class_id%TYPE;
    location_id location_table.location_id%TYPE;
    cnt NUMBER;
BEGIN
    SELECT COUNT(*) INTO cnt FROM character_table WHERE UPPER(character_name) = UPPER(p_character_name);
    IF (cnt = 0) THEN
        SELECT user_id INTO user_id FROM user_table WHERE UPPER(user_login) = UPPER(p_user_login);
        SELECT race_id INTO race_id FROM race_table WHERE UPPER(race_name) = UPPER(p_race_name);
        SELECT class_id INTO class_id FROM class_table WHERE UPPER(class_name) = UPPER(p_class_name);
        location_id := GAMEDBADMIN.race_location(p_race_name);
        INSERT INTO character_table(character_user, character_name, character_race, character_class, character_location, character_level) VALUES(user_id, UPPER(p_character_name), race_id, class_id, location_id, 1);
        COMMIT;
    ELSE
        RAISE_APPLICATION_ERROR(-20005, 'This character name using in system');
    END IF;
END create_character;

-------------------------CHANGE_CHARACTER-------------------------

CREATE OR REPLACE PROCEDURE change_character
    (p_character_name IN character_table.character_name%TYPE,
    p_change_character_name IN character_table.character_name%TYPE)
IS
    cnt NUMBER;
BEGIN
    SELECT COUNT(*) INTO cnt FROM character_table WHERE UPPER(character_name) = UPPER(p_character_name);
    IF (cnt != 0) THEN
        SELECT COUNT(*) INTO cnt FROM character_table WHERE UPPER(character_name) = UPPER(p_change_character_name);
        IF (cnt = 0) THEN
            UPDATE character_table SET character_table.character_name = UPPER(p_change_character_name) WHERE UPPER(character_table.character_name) = UPPER(p_character_name);
            COMMIT;
        ELSE
            RAISE_APPLICATION_ERROR(-20007, 'Name is used');
        END IF;
    ELSE
        RAISE_APPLICATION_ERROR(-20006, 'Character is not found');
    END IF;
END change_character;

-------------------------DELETE_CHARACTER-------------------------

CREATE OR REPLACE PROCEDURE delete_character
    (p_character_name IN character_table.character_name%TYPE)
IS
    cnt NUMBER;
    chr_id character_table.character_id%TYPE;
BEGIN
    SELECT COUNT(*) INTO cnt FROM character_table WHERE UPPER(character_name) = UPPER(p_character_name);
    IF (cnt != 0) THEN
        SELECT character_id INTO chr_id FROM character_table WHERE UPPER(character_name) = UPPER(p_character_name);
        GAMEDBADMIN.delete_skill(chr_id);
        GAMEDBADMIN.delete_item(chr_id);
        DELETE FROM character_table WHERE UPPER(character_table.character_name) = UPPER(p_character_name);
        COMMIT;
    ELSE
        RAISE_APPLICATION_ERROR(-20006, 'Character is not found');
    END IF;
END delete_character;

-------------------------DELETE_CHARACTER_BY_USER-------------------------

CREATE OR REPLACE PROCEDURE delete_character_by_user
    (p_user_id IN user_table.user_id%TYPE)
IS
    CURSOR curs_character IS SELECT character_id FROM character_table WHERE UPPER(character_user) = UPPER(p_user_id);
    rec_character curs_character%ROWTYPE;
    --chr_id character_table.character_id%TYPE;
BEGIN
    FOR rec_character IN curs_character
    LOOP
        GAMEDBADMIN.delete_skill(rec_character.character_id);
        GAMEDBADMIN.delete_item(rec_character.character_id);
        DELETE FROM character_table WHERE character_table.character_user = p_user_id;
    END LOOP;
    COMMIT;
END delete_character_by_user;

-------------------------DELETE_SKILL-------------------------

CREATE OR REPLACE PROCEDURE delete_skill
    (p_character_id IN character_skill_table.character_skill_character%TYPE)
IS
BEGIN
    DELETE FROM character_skill_table WHERE character_skill_character = p_character_id;
    COMMIT;
END delete_skill;

-------------------------DELETE_ITEM-------------------------

CREATE OR REPLACE PROCEDURE delete_item
    (p_character_id IN character_item_table.character_item_character%TYPE)
IS
BEGIN
    DELETE FROM character_item_table WHERE character_item_character = p_character_id;
    COMMIT;
END delete_item;

-------------------------RACE_LOCATION-------------------------

CREATE OR REPLACE FUNCTION race_location
    (p_race_name IN race_table.race_name%TYPE)
    RETURN race_table.race_location%TYPE
IS
    cnt NUMBER;
    race_location_id race_table.race_location%TYPE;
BEGIN
    SELECT COUNT(*) INTO cnt FROM race_table WHERE UPPER(race_name) = UPPER(p_race_name);
    IF (cnt != 0) THEN
        SELECT race_table.race_location INTO race_location_id FROM race_table WHERE UPPER(race_name) = UPPER(p_race_name);
        COMMIT;
    ELSE
        RAISE_APPLICATION_ERROR(-20008, 'Race is not found');
    END IF;
RETURN race_location_id;
END race_location;

-------------------------CHARACTER_LIMIT-------------------------

CREATE OR REPLACE PROCEDURE character_limit
    (p_user_login IN user_table.user_login%TYPE,
    o_is_free OUT user_table.user_donat%TYPE)
IS
    cnt NUMBER;
    p_user_donat user_table.user_donat%TYPE;
BEGIN
    SELECT COUNT(*) INTO cnt FROM character_info_view WHERE UPPER(user_login) = UPPER(p_user_login);
    IF (cnt BETWEEN 0 AND 5) THEN
        SELECT user_donat INTO p_user_donat FROM user_table WHERE UPPER(user_login) = UPPER(p_user_login);
        IF ((UPPER(p_user_donat) = 'NO' AND cnt < 3) OR (UPPER(p_user_donat) = 'YES' AND cnt < 5)) THEN
            o_is_free := 'TRUE';
        ELSE
            o_is_free := 'FALSE';
        END IF;
    ELSE
        RAISE_APPLICATION_ERROR(-20009, 'Limit of person is reached');
    END IF;
END character_limit;

-------------------------CHANGE_LOCATION-------------------------

CREATE OR REPLACE PROCEDURE change_location
    (p_character_name IN character_table.character_name%TYPE,
    p_location_name IN location_table.location_name%TYPE)
IS
    cnt NUMBER;
    lctn location_table.location_id%TYPE;
BEGIN
    SELECT COUNT(*) INTO cnt FROM character_table WHERE UPPER(character_name) = UPPER(p_character_name);
    IF (cnt != 0) THEN
        SELECT COUNT(*) INTO cnt FROM location_table WHERE UPPER(location_name) = UPPER(p_location_name);
        IF (cnt != 0) THEN
            SELECT location_id INTO lctn FROM location_table WHERE UPPER(location_name) = UPPER(p_location_name);
            UPDATE character_table SET character_table.character_location = lctn WHERE UPPER(character_table.character_name) = UPPER(p_character_name);
            COMMIT;
        ELSE
            RAISE_APPLICATION_ERROR(-200010, 'Location is not found');
        END IF;
    ELSE
        RAISE_APPLICATION_ERROR(-20006, 'Character is not found');
    END IF;
END change_location;

-------------------------SET_DONAT-------------------------

CREATE OR REPLACE PROCEDURE set_donat
    (p_user_login IN user_table.user_login%TYPE,
    p_user_donat IN user_table.user_donat%TYPE)
IS
    cnt NUMBER;
BEGIN
    SELECT COUNT(*) INTO cnt FROM user_table WHERE UPPER(user_login) = UPPER(p_user_login);
    IF (cnt != 0) THEN
        UPDATE user_table SET user_donat = UPPER(p_user_donat) WHERE UPPER(user_login) = UPPER(p_user_login);
        COMMIT;
    ELSE
        RAISE_APPLICATION_ERROR(-20003, 'User is not found');
    END IF;
END set_donat;

-------------------------MONSTER_SKILL_EXPORT-------------------------

CREATE OR REPLACE PROCEDURE monster_skill_export
IS
    rc sys_refcursor;
    doc DBMS_XMLDOM.DOMDocument;
BEGIN
    OPEN rc FOR SELECT monster_skill_monster, monster_skill_skill FROM monster_skill_table;
    doc := DBMS_XMLDOM.NewDOMDocument(XMLTYPE(rc));
    DBMS_XMLDOM.WRITETOFILE(doc, 'MONSTER_SKILL_XML/monster_skill.xml');
END monster_skill_export;

-------------------------MONSTER_SKILL_IMPORT-------------------------

CREATE OR REPLACE PROCEDURE monster_skill_import
IS
BEGIN
    DELETE FROM monster_skill_table;
    INSERT INTO monster_skill_table (monster_skill_monster, monster_skill_skill)
    SELECT ExtractValue(VALUE(monster_skill_xml), '//MONSTER_SKILL_MONSTER') AS monster_skill_monster,
        ExtractValue(VALUE(monster_skill_xml), '//MONSTER_SKILL_SKILL') AS monster_skill_skill
    FROM TABLE(XMLSequence(EXTRACT(XMLTYPE(bfilename('MONSTER_SKILL_XML', 'monster_skill.xml'),
    nls_charset_id('UTF-8')),'/ROWSET/ROW'))) monster_skill_xml;
END monster_skill_import;

-------------------------INSERT_100K-------------------------

CREATE OR REPLACE PROCEDURE insert_100k
IS
BEGIN
    FOR i IN 1 .. 100000 LOOP
    INSERT INTO monster_skill_table(monster_skill_monster, monster_skill_skill) VALUES(4, 1);
    END LOOP;
END insert_100k;

BEGIN
insert_100k();
END;

delete monster_skill_table;

select * from skill_table;

-------------------------CHARACTER_SKILL-------------------------

CREATE OR REPLACE PROCEDURE character_skill
    (p_character_name IN character_table.character_name%TYPE)
IS
    cnt NUMBER;
    CURSOR skill_cursor IS SELECT character_id, skill_id FROM character_table INNER JOIN skill_table ON character_race = skill_race AND character_class = skill_class AND character_level >= skill_level WHERE UPPER(character_name) = UPPER(p_character_name);
    rec_skill skill_cursor%ROWTYPE;
BEGIN
    FOR rec_skill IN skill_cursor
    LOOP
        SELECT COUNT(*) INTO cnt FROM character_skill_table WHERE character_skill_character = rec_skill.character_id AND character_skill_skill = rec_skill.skill_id;
        IF (cnt = 0) THEN
            INSERT INTO character_skill_table(character_skill_character, character_skill_skill) VALUES (rec_skill.character_id, rec_skill.skill_id);
        END IF;
    END LOOP;
END character_skill;

-------------------------CHARACTER_SKILL_LOAD-------------------------

CREATE OR REPLACE PROCEDURE character_skill_load
    (p_character_name IN character_table.character_name%TYPE,
    p_skill_level IN skill_table.skill_level%TYPE,
    o_skill_health OUT skill_table.skill_health%TYPE,
    o_skill_mana OUT skill_table.skill_mana%TYPE,
    o_skill_type OUT skill_table.skill_type%TYPE)
IS
BEGIN
    SELECT skill_health, skill_mana, skill_type INTO o_skill_health, o_skill_mana, o_skill_type FROM GAMEDBADMIN.skill_table 
    INNER JOIN GAMEDBADMIN.character_skill_table 
    ON skill_id = character_skill_skill
    INNER JOIN GAMEDBADMIN.character_table 
    ON character_skill_character = character_id WHERE UPPER(character_name) = UPPER(p_character_name) AND skill_level = p_skill_level 
    ORDER BY skill_level ASC, skill_name ASC;
END character_skill_load;

-------------------------DROP_ITEM-------------------------

CREATE OR REPLACE PROCEDURE drop_item
    (p_character_name IN character_table.character_name%TYPE,
    p_monster_name IN monster_table.monster_name%TYPE)
IS
    CURSOR item_cursor IS SELECT monster_item_item, monster_item_chance FROM monster_item_table INNER JOIN monster_table ON monster_item_monster = monster_id WHERE UPPER(monster_name) = UPPER(p_monster_name);
    rec_item item_cursor%ROWTYPE;
    rand PLS_INTEGER;
    chr character_table.character_id%TYPE;
BEGIN
    SELECT character_id INTO chr FROM character_table WHERE UPPER(character_name) = UPPER(p_character_name);
    FOR rec_item IN item_cursor
    LOOP
        rand := DBMS_RANDOM.VALUE(1,100);
        IF (rec_item.monster_item_chance >= rand) THEN
            INSERT INTO character_item_table(character_item_character, character_item_item) VALUES (chr, rec_item.monster_item_item);
            COMMIT;
        END IF;
    END LOOP;
END drop_item;

-------------------------LOCATION_IMAGE-------------------------

CREATE OR REPLACE DIRECTORY location_resources AS 'D:\GameDB\Resources\Location';

CREATE OR REPLACE PROCEDURE location_image
    (p_location_name IN location_table.location_name%TYPE,
    p_image_name IN location_table.location_name%TYPE)
IS
    src_file BFILE;
    dst_file BLOB;
    lgh_file BINARY_INTEGER;
BEGIN
    src_file := bfilename('LOCATION_RESOURCES', p_image_name);
    SELECT location_blob INTO dst_file FROM location_table WHERE UPPER(location_name) = UPPER(p_location_name) FOR UPDATE;
    DBMS_LOB.FILEOPEN(src_file, DBMS_LOB.FILE_READONLY);
    lgh_file := DBMS_LOB.GETLENGTH(src_file);
    DBMS_LOB.LOADFROMFILE(dst_file, src_file, lgh_file);
    UPDATE location_table SET location_blob = dst_file WHERE UPPER(location_name) = UPPER(p_location_name);
    DBMS_LOB.FILECLOSE(src_file);
    COMMIT;
END location_image;

-------------------------NPC_IMAGE-------------------------

CREATE OR REPLACE DIRECTORY npc_resources AS 'D:\GameDB\Resources\NPC';

CREATE OR REPLACE PROCEDURE npc_image
    (p_npc_name IN npc_table.npc_name%TYPE,
    p_image_name IN npc_table.npc_name%TYPE)
IS
    src_file BFILE;
    dst_file BLOB;
    lgh_file BINARY_INTEGER;
BEGIN
    src_file := bfilename('NPC_RESOURCES', p_image_name);
    SELECT npc_blob INTO dst_file FROM npc_table WHERE UPPER(npc_name) = UPPER(p_npc_name) FOR UPDATE;
    DBMS_LOB.FILEOPEN(src_file, DBMS_LOB.FILE_READONLY);
    lgh_file := DBMS_LOB.GETLENGTH(src_file);
    DBMS_LOB.LOADFROMFILE(dst_file, src_file, lgh_file);
    UPDATE npc_table SET npc_blob = dst_file WHERE UPPER(npc_name) = UPPER(p_npc_name);
    DBMS_LOB.FILECLOSE(src_file);
    COMMIT;
END npc_image;

-------------------------MONSTER_IMAGE-------------------------

CREATE OR REPLACE DIRECTORY monster_resources AS 'D:\GameDB\Resources\Monster';

CREATE OR REPLACE PROCEDURE monster_image
    (p_monster_name IN monster_table.monster_name%TYPE,
    p_image_name IN monster_table.monster_name%TYPE)
IS
    src_file BFILE;
    dst_file BLOB;
    lgh_file BINARY_INTEGER;
BEGIN
    src_file := bfilename('MONSTER_RESOURCES', p_image_name);
    SELECT monster_blob INTO dst_file FROM monster_table WHERE UPPER(monster_name) = UPPER(p_monster_name) FOR UPDATE;
    DBMS_LOB.FILEOPEN(src_file, DBMS_LOB.FILE_READONLY);
    lgh_file := DBMS_LOB.GETLENGTH(src_file);
    DBMS_LOB.LOADFROMFILE(dst_file, src_file, lgh_file);
    UPDATE monster_table SET monster_blob = dst_file WHERE UPPER(monster_name) = UPPER(p_monster_name);
    DBMS_LOB.FILECLOSE(src_file);
    COMMIT;
END monster_image;

-------------------------SKILL_IMAGE-------------------------

CREATE OR REPLACE DIRECTORY skill_resources AS 'D:\GameDB\Resources\Skill';

CREATE OR REPLACE PROCEDURE skill_image 
    (p_skill_name IN skill_table.skill_name%TYPE,
    p_image_name IN skill_table.skill_name%TYPE)
IS
    src_file BFILE;
    dst_file BLOB;
    lgh_file BINARY_INTEGER;
BEGIN
    src_file := bfilename('SKILL_RESOURCES', p_image_name);
    SELECT skill_blob INTO dst_file FROM skill_table WHERE UPPER(skill_name) = UPPER(p_skill_name) FOR UPDATE;
    DBMS_LOB.FILEOPEN(src_file, DBMS_LOB.FILE_READONLY);
    lgh_file := DBMS_LOB.GETLENGTH(src_file);
    DBMS_LOB.LOADFROMFILE(dst_file, src_file, lgh_file);
    UPDATE skill_table SET skill_blob = dst_file WHERE UPPER(skill_name) = UPPER(p_skill_name);
    DBMS_LOB.FILECLOSE(src_file);
    COMMIT;
END skill_image;

-------------------------ITEM_IMAGE-------------------------

CREATE OR REPLACE DIRECTORY item_resources AS 'D:\GameDB\Resources\Item';

CREATE OR REPLACE PROCEDURE item_image 
    (p_item_name IN item_table.item_name%TYPE,
    p_image_name IN item_table.item_name%TYPE)
IS
    src_file BFILE;
    dst_file BLOB;
    lgh_file BINARY_INTEGER;
BEGIN
    src_file := bfilename('ITEM_RESOURCES', p_image_name);
    SELECT item_blob INTO dst_file FROM item_table WHERE UPPER(item_name) = UPPER(p_item_name) FOR UPDATE;
    DBMS_LOB.FILEOPEN(src_file, DBMS_LOB.FILE_READONLY);
    lgh_file := DBMS_LOB.GETLENGTH(src_file);
    DBMS_LOB.LOADFROMFILE(dst_file, src_file, lgh_file);
    UPDATE item_table SET item_blob = dst_file WHERE UPPER(item_name) = UPPER(p_item_name);
    DBMS_LOB.FILECLOSE(src_file);
    COMMIT;
END item_image;

-------------------------HEALTH_MANA-------------------------

CREATE OR REPLACE PROCEDURE health_mana_heal
IS
    CURSOR health_mana_cursor IS SELECT * FROM character_table;
    rec_health_mana health_mana_cursor%ROWTYPE;
BEGIN
    FOR rec_health_mana IN health_mana_cursor
    LOOP
        IF (rec_health_mana.character_health + 5 < rec_health_mana.character_max_health) THEN
            UPDATE character_table SET character_health = character_health + 5 WHERE UPPER(character_name) = UPPER(rec_health_mana.character_name);
        ELSE
            UPDATE character_table SET character_health = character_max_health WHERE UPPER(character_name) = UPPER(rec_health_mana.character_name);
        END IF;
        
        IF (rec_health_mana.character_mana + 5 < rec_health_mana.character_max_mana) THEN
            UPDATE character_table SET character_mana = character_mana + 5 WHERE UPPER(character_name) = UPPER(rec_health_mana.character_name);
        ELSE
            UPDATE character_table SET character_mana = character_max_mana WHERE UPPER(character_name) = UPPER(rec_health_mana.character_name);
        END IF;
    END LOOP;
    COMMIT;
END health_mana_heal;

SELECT * FROM character_table;
UPDATE character_table SET character_health = 0 WHERE UPPER(character_name) = UPPER('ALASTOR');
UPDATE character_table SET character_mana = 0 WHERE UPPER(character_name) = UPPER('ALASTOR');
COMMIT;

-------------------------START_JOB-------------------------

CREATE OR REPLACE PROCEDURE start_job
IS
BEGIN
    DBMS_SCHEDULER.RUN_JOB('GAMEDB_JOB');
END start_job;

-------------------------END_JOB-------------------------

CREATE OR REPLACE PROCEDURE end_job
IS
BEGIN
    DBMS_SCHEDULER.STOP_JOB('GAMEDB_JOB');
END end_job;

-------------------------SET_HEALTH_MANA-------------------------

CREATE OR REPLACE PROCEDURE set_health_mana
    (p_character_health IN character_table.character_health%TYPE,
    p_character_mana IN character_table.character_mana%TYPE,
    p_character_name IN character_table.character_name%TYPE)
IS
BEGIN
    UPDATE character_table SET character_health = p_character_health, character_mana = p_character_mana WHERE UPPER(character_name) = UPPER(p_character_name);
END set_health_mana;
