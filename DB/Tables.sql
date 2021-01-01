ALTER SESSION SET "_ORACLE_SCRIPT" = TRUE;

SELECT * FROM user_tables;

-------------------------ROLE-------------------------

CREATE TABLE role_table (
    role_id NUMBER(10) GENERATED AS IDENTITY(START WITH 1 INCREMENT BY 1),
    role_name VARCHAR2(30) NOT NULL,
    CONSTRAINT role_pk PRIMARY KEY (role_id)
);

INSERT INTO role_table(role_name) VALUES('PLAYER');
INSERT INTO role_table(role_name) VALUES('OWNER');

SELECT * FROM role_table;

DROP TABLE role_table;

-------------------------USER-------------------------

CREATE TABLE user_table (
    user_id NUMBER(10) GENERATED AS IDENTITY(START WITH 1 INCREMENT BY 1),
    user_login VARCHAR2(30) NOT NULL,
    user_password VARCHAR2(200) NOT NULL,
    user_name VARCHAR2(30) NOT NULL,
    user_surname VARCHAR2(30) NOT NULL,
    user_donat VARCHAR2(30) DEFAULT 'NO' NOT NULL,
    user_role NUMBER(10) NOT NULL,
    CONSTRAINT user_pk PRIMARY KEY (user_id),
    CONSTRAINT user_role_fk FOREIGN KEY (user_role) REFERENCES role_table(role_id)
);

SELECT * FROM user_table;

UPDATE user_table SET user_role = 2 WHERE user_login = 'WEEBEEZ';

DROP TABLE user_table;

-------------------------RACE-------------------------

CREATE TABLE race_table (
    race_id NUMBER(10) GENERATED AS IDENTITY(START WITH 1 INCREMENT BY 1),
    race_name VARCHAR2(30) NOT NULL,
    race_location NUMBER(10) NOT NULL,
    CONSTRAINT race_pk PRIMARY KEY (race_id),
    CONSTRAINT race_location_fk FOREIGN KEY (race_location) REFERENCES location_table(location_id)
);

INSERT INTO race_table(race_name, race_location) VALUES('ELF', 13);
INSERT INTO race_table(race_name, race_location) VALUES('ORC', 11);
INSERT INTO race_table(race_name, race_location) VALUES('HUMAN', 15);
INSERT INTO race_table(race_name, race_location) VALUES('UNDEAD', 17);
INSERT INTO race_table(race_name, race_location) VALUES('ANGEL', 23);
INSERT INTO race_table(race_name, race_location) VALUES('DEMON', 5);

SELECT * FROM race_table;

DROP TABLE race_table;

-------------------------CLASS-------------------------

CREATE TABLE class_table (
    class_id NUMBER(10) GENERATED AS IDENTITY(START WITH 1 INCREMENT BY 1),
    class_name VARCHAR2(30) NOT NULL,
    CONSTRAINT class_pk PRIMARY KEY (class_id)
);

INSERT INTO class_table(class_name) VALUES('WARRIOR');
INSERT INTO class_table(class_name) VALUES('KILLER');
INSERT INTO class_table(class_name) VALUES('MAGE');
INSERT INTO class_table(class_name) VALUES('SUPPORT');

SELECT * FROM class_table;

DROP TABLE class_table;

-------------------------LOCATION-------------------------

CREATE TABLE location_table (
    location_id NUMBER(10) GENERATED AS IDENTITY(START WITH 1 INCREMENT BY 1),
    location_name VARCHAR2(30) NOT NULL,
    location_x NUMBER(10) NOT NULL,
    location_y NUMBER(10) NOT NULL,
    location_z NUMBER(10) NOT NULL,
    location_min_level NUMBER(10) NOT NULL,
    location_max_level NUMBER(10) NOT NULL,
    location_blob BLOB DEFAULT EMPTY_BLOB(),
    CONSTRAINT location_pk PRIMARY KEY (location_id)
);

INSERT INTO location_table(location_name, location_x, location_y, location_z, location_min_level, location_max_level) VALUES('FARALON', 0, 0, 0, 11, 15);
INSERT INTO location_table(location_name, location_x, location_y, location_z, location_min_level, location_max_level) VALUES('TANAAN JUNGLE', 1, 0, 0, 6, 10);
INSERT INTO location_table(location_name, location_x, location_y, location_z, location_min_level, location_max_level) VALUES('ASHRAN', 2, 0, 0, 11, 15);
INSERT INTO location_table(location_name, location_x, location_y, location_z, location_min_level, location_max_level) VALUES('HIJAL', 0, 1, 0, 6, 10);
INSERT INTO location_table(location_name, location_x, location_y, location_z, location_min_level, location_max_level) VALUES('PENTAGRAMM CITY', 1, 1, 0, 1, 5);
INSERT INTO location_table(location_name, location_x, location_y, location_z, location_min_level, location_max_level) VALUES('KARAZHAN', 2, 1, 0, 6, 10);
INSERT INTO location_table(location_name, location_x, location_y, location_z, location_min_level, location_max_level) VALUES('SURAMAR', 0, 2, 0, 11, 15);
INSERT INTO location_table(location_name, location_x, location_y, location_z, location_min_level, location_max_level) VALUES('BRILL', 1, 2, 0, 6, 10);
INSERT INTO location_table(location_name, location_x, location_y, location_z, location_min_level, location_max_level) VALUES('ACERUS', 2, 2, 0, 11, 15);

INSERT INTO location_table(location_name, location_x, location_y, location_z, location_min_level, location_max_level) VALUES('ASHENVALE', 0, 0, 1, 6, 10);
INSERT INTO location_table(location_name, location_x, location_y, location_z, location_min_level, location_max_level) VALUES('ORGRIMMAR', 1, 0, 1, 1, 5);
INSERT INTO location_table(location_name, location_x, location_y, location_z, location_min_level, location_max_level) VALUES('ALTERAC', 2, 0, 1, 6, 10);
INSERT INTO location_table(location_name, location_x, location_y, location_z, location_min_level, location_max_level) VALUES('DARNAS', 0, 1, 1, 1, 5);
INSERT INTO location_table(location_name, location_x, location_y, location_z, location_min_level, location_max_level) VALUES('NEXUS', 1, 1, 1, 16, 20);
INSERT INTO location_table(location_name, location_x, location_y, location_z, location_min_level, location_max_level) VALUES('STORMWIND', 2, 1, 1, 1, 5);
INSERT INTO location_table(location_name, location_x, location_y, location_z, location_min_level, location_max_level) VALUES('GILNEAS', 0, 2, 1, 6, 10);
INSERT INTO location_table(location_name, location_x, location_y, location_z, location_min_level, location_max_level) VALUES('NAXXRAMAS', 1, 2, 1, 1, 5);
INSERT INTO location_table(location_name, location_x, location_y, location_z, location_min_level, location_max_level) VALUES('STRATHOLME', 2, 2, 1, 6, 10);

INSERT INTO location_table(location_name, location_x, location_y, location_z, location_min_level, location_max_level) VALUES('AZSHARA', 0, 0, 2, 11, 15);
INSERT INTO location_table(location_name, location_x, location_y, location_z, location_min_level, location_max_level) VALUES('NAGRAND', 1, 0, 2, 6, 10);
INSERT INTO location_table(location_name, location_x, location_y, location_z, location_min_level, location_max_level) VALUES('SHATTRATH', 2, 0, 2, 11, 15);
INSERT INTO location_table(location_name, location_x, location_y, location_z, location_min_level, location_max_level) VALUES('EXODAR', 0, 1, 2, 6, 10);
INSERT INTO location_table(location_name, location_x, location_y, location_z, location_min_level, location_max_level) VALUES('SILVER TOWN', 1, 1, 2, 1, 5);
INSERT INTO location_table(location_name, location_x, location_y, location_z, location_min_level, location_max_level) VALUES('TALADOR', 2, 1, 2, 6, 10);
INSERT INTO location_table(location_name, location_x, location_y, location_z, location_min_level, location_max_level) VALUES('DARK SHORES', 0, 2, 2, 11, 15);
INSERT INTO location_table(location_name, location_x, location_y, location_z, location_min_level, location_max_level) VALUES('SHADOW LANDS', 1, 2, 2, 6, 10);
INSERT INTO location_table(location_name, location_x, location_y, location_z, location_min_level, location_max_level) VALUES('ULDUAR', 2, 2, 2, 11, 15);

BEGIN
location_image('FARALON', 'Faralon.png');
location_image('TANAAN JUNGLE', 'Tanaan jungle.png');
location_image('ASHRAN', 'Ashran.png');
location_image('HIJAL', 'Hijal.png');
location_image('PENTAGRAMM CITY', 'Pentagramm city.png');
location_image('KARAZHAN', 'Karazhan.png');
location_image('SURAMAR', 'Suramar.png');
location_image('BRILL', 'Brill.png');
location_image('ACERUS', 'Acerus.png');
location_image('ASHENVALE', 'Ashenvale.png');
location_image('ORGRIMMAR', 'Orgrimmar.png');
location_image('ALTERAC', 'Alterac.png');
location_image('DARNAS', 'Darnas.png');
location_image('NEXUS', 'Nexus.png');
location_image('STORMWIND', 'Stormwind.png');
location_image('GILNEAS', 'Gilneas.png');
location_image('NAXXRAMAS', 'Naxxramas.png');
location_image('STRATHOLME', 'Stratholme.png');
location_image('AZSHARA', 'Azshara.png');
location_image('NAGRAND', 'Nagrand.png');
location_image('SHATTRATH', 'Shattrath.png');
location_image('EXODAR', 'Exodar.png');
location_image('SILVER TOWN', 'Silver town.png');
location_image('TALADOR', 'Talador.png');
location_image('DARK SHORES', 'Dark shores.png');
location_image('SHADOW LANDS', 'Shadow lands.png');
location_image('ULDUAR', 'Ulduar.png');
END;

SELECT * FROM location_table;

DROP TABLE location_table;

-------------------------CHARACTER-------------------------

CREATE TABLE character_table (
    character_id NUMBER(10) GENERATED AS IDENTITY(START WITH 1 INCREMENT BY 1),
    character_user NUMBER(10) NOT NULL,
    character_name VARCHAR2(30) NOT NULL,
    character_race NUMBER(10) NOT NULL,
    character_class NUMBER(10) NOT NULL,
    character_location NUMBER(10) NOT NULL,
    character_level NUMBER(10) DEFAULT 1 NOT NULL,
    character_exp NUMBER(10) DEFAULT 0 NOT NULL,
    character_health NUMBER(10) DEFAULT 40 NOT NULL,
    character_max_health NUMBER(10) DEFAULT 40 NOT NULL,
    character_mana NUMBER(10) DEFAULT 20 NOT NULL,
    character_max_mana NUMBER(10) DEFAULT 20 NOT NULL,
    character_power NUMBER(10) DEFAULT 5 NOT NULL,
    character_speed NUMBER(10) DEFAULT 3 NOT NULL,
    character_mind NUMBER(10) DEFAULT 3 NOT NULL,
    CONSTRAINT character_pk PRIMARY KEY (character_id),
    CONSTRAINT character_user_fk FOREIGN KEY (character_user) REFERENCES user_table(user_id),
    CONSTRAINT character_race_fk FOREIGN KEY (character_race) REFERENCES race_table(race_id),
    CONSTRAINT character_class_fk FOREIGN KEY (character_class) REFERENCES class_table(class_id),
    CONSTRAINT character_location_fk FOREIGN KEY (character_location) REFERENCES location_table(location_id)
);

SELECT * FROM character_table;

DROP TABLE character_table;

-------------------------MONSTER-------------------------

CREATE TABLE monster_table (
    monster_id NUMBER(10) GENERATED AS IDENTITY(START WITH 1 INCREMENT BY 1),
    monster_name VARCHAR2(30) NOT NULL,
    monster_race NUMBER(10) NOT NULL,
    monster_class NUMBER(10) NOT NULL,
    monster_location NUMBER(10) NOT NULL,
    monster_level NUMBER(10) NOT NULL,
    monster_health NUMBER(10) NOT NULL,
    monster_max_health NUMBER(10) NOT NULL,
    monster_mana NUMBER(10) NOT NULL,
    monster_max_mana NUMBER(10) NOT NULL,
    monster_power NUMBER(10) NOT NULL,
    monster_speed NUMBER(10) NOT NULL,
    monster_mind NUMBER(10) NOT NULL,
    monster_blob BLOB DEFAULT EMPTY_BLOB(),
    CONSTRAINT monster_pk PRIMARY KEY (monster_id),
    CONSTRAINT monster_race_fk FOREIGN KEY (monster_race) REFERENCES race_table(race_id),
    CONSTRAINT monster_class_fk FOREIGN KEY (monster_class) REFERENCES class_table(class_id),
    CONSTRAINT monster_location_fk FOREIGN KEY (monster_location) REFERENCES location_table(location_id)
);

INSERT INTO monster_table(monster_name, monster_race, monster_class, monster_location, monster_level) VALUES('HUMAN-GUARDIAN', 1, 1, 1, 1);
INSERT INTO monster_table(monster_name, monster_race, monster_class, monster_location, monster_level) VALUES('DWARF-SNIPER', 5, 9, 1, 1);
INSERT INTO monster_table(monster_name, monster_race, monster_class, monster_location, monster_level) VALUES('GNOME-ENGINEER', 6, 10, 1, 1);

SELECT * FROM monster_table;

DROP TABLE monster_table;

-------------------------PROFESSION-------------------------

CREATE TABLE profession_table (
    profession_id NUMBER(10) GENERATED AS IDENTITY(START WITH 1 INCREMENT BY 1),
    profession_name VARCHAR2(30) NOT NULL,
    CONSTRAINT profession_pk PRIMARY KEY (profession_id)
);

INSERT INTO profession_table(profession_name) VALUES('MINER');
INSERT INTO profession_table(profession_name) VALUES('SKINNER');
INSERT INTO profession_table(profession_name) VALUES('HERBALIST');
INSERT INTO profession_table(profession_name) VALUES('BLACKSMITH');
INSERT INTO profession_table(profession_name) VALUES('CLOTHIER');
INSERT INTO profession_table(profession_name) VALUES('ALCHIEMIST');
INSERT INTO profession_table(profession_name) VALUES('JEWELER');
INSERT INTO profession_table(profession_name) VALUES('VENDOR');
INSERT INTO profession_table(profession_name) VALUES('QUESTER');

SELECT * FROM profession_table;

DROP TABLE profession_table;

-------------------------NPC-------------------------

CREATE TABLE npc_table (
    npc_id NUMBER(10) GENERATED AS IDENTITY(START WITH 1 INCREMENT BY 1),
    npc_name VARCHAR2(30) NOT NULL,
    npc_race NUMBER(10) NOT NULL,
    npc_profession NUMBER(10) NOT NULL,
    npc_location NUMBER(10) NOT NULL,
    npc_level NUMBER(10) NOT NULL,
    npc_blob BLOB DEFAULT EMPTY_BLOB(),
    CONSTRAINT npc_pk PRIMARY KEY (npc_id),
    CONSTRAINT npc_race_fk FOREIGN KEY (npc_race) REFERENCES race_table(race_id),
    CONSTRAINT npc_profession_fk FOREIGN KEY (npc_profession) REFERENCES profession_table(profession_id),
    CONSTRAINT npc_location_fk FOREIGN KEY (npc_location) REFERENCES location_table(location_id)
);

INSERT INTO npc_table(npc_name, npc_race, npc_profession, npc_location, npc_level) VALUES('ANNA', 1, 1, 1, 1);
INSERT INTO npc_table(npc_name, npc_race, npc_profession, npc_location, npc_level) VALUES('EDUARD', 2, 2, 2, 2);
INSERT INTO npc_table(npc_name, npc_race, npc_profession, npc_location, npc_level) VALUES('MAKS', 3, 3, 3, 3);
INSERT INTO npc_table(npc_name, npc_race, npc_profession, npc_location, npc_level) VALUES('TERESA', 4, 4, 4, 4);
INSERT INTO npc_table(npc_name, npc_race, npc_profession, npc_location, npc_level) VALUES('ELIZABETH', 5, 5, 5, 5);
INSERT INTO npc_table(npc_name, npc_race, npc_profession, npc_location, npc_level) VALUES('SAM', 6, 6, 6, 6);
INSERT INTO npc_table(npc_name, npc_race, npc_profession, npc_location, npc_level) VALUES('FINN', 7, 7, 7, 7);
INSERT INTO npc_table(npc_name, npc_race, npc_profession, npc_location, npc_level) VALUES('JAKE', 8, 8, 8, 8);
INSERT INTO npc_table(npc_name, npc_race, npc_profession, npc_location, npc_level) VALUES('DIN', 9, 9, 9, 9);

SELECT * FROM npc_table;

DROP TABLE npc_table;

-------------------------SKILL_TYPE-------------------------

CREATE TABLE skill_type_table (
    skill_type_id NUMBER(10) GENERATED AS IDENTITY(START WITH 1 INCREMENT BY 1),
    skill_type_name VARCHAR2(30) NOT NULL,
    CONSTRAINT skill_type_pk PRIMARY KEY (skill_type_id)
);

INSERT INTO skill_type_table(skill_type_name) VALUES('DAMAGE');
INSERT INTO skill_type_table(skill_type_name) VALUES('HEAL');

SELECT * FROM skill_type_table;

DROP TABLE skill_type_table;

-------------------------SKILL-------------------------

CREATE TABLE skill_table (
    skill_id NUMBER(10) GENERATED AS IDENTITY(START WITH 1 INCREMENT BY 1),
    skill_name VARCHAR2(30) NOT NULL,
    skill_race NUMBER(10) NOT NULL,
    skill_class NUMBER(10) NOT NULL,
    skill_type NUMBER(10) NOT NULL,
    skill_health NUMBER(10) NOT NULL,
    skill_mana NUMBER(10) NOT NULL,
    skill_level NUMBER(10) NOT NULL,
    skill_blob BLOB DEFAULT EMPTY_BLOB(),
    CONSTRAINT skill_pk PRIMARY KEY (skill_id),
    CONSTRAINT skill_race_fk FOREIGN KEY (skill_race) REFERENCES race_table(race_id),
    CONSTRAINT skill_class_fk FOREIGN KEY (skill_class) REFERENCES class_table(class_id),
    CONSTRAINT skill_type_fk FOREIGN KEY (skill_type) REFERENCES skill_type_table(skill_type_id)
);

INSERT INTO skill_table(skill_name, skill_race, skill_class, skill_type, skill_level) VALUES('HUMAN-DAMAGE-SKILL', 1, 1, 1, 1);
INSERT INTO skill_table(skill_name, skill_race, skill_class, skill_type, skill_level) VALUES('HUMAN-HEAL-SKILL', 1, 1, 2, 1);

SELECT * FROM skill_table;

DROP TABLE skill_table;

-------------------------CHARACTER_SKILL-------------------------

CREATE TABLE character_skill_table (
    character_skill_id NUMBER(10) GENERATED AS IDENTITY(START WITH 1 INCREMENT BY 1),
    character_skill_character NUMBER(10) NOT NULL,
    character_skill_skill NUMBER(10) NOT NULL,
    CONSTRAINT character_skill_pk PRIMARY KEY (character_skill_id),
    CONSTRAINT character_skill_character_fk FOREIGN KEY (character_skill_character) REFERENCES character_table(character_id),
    CONSTRAINT character_skill_skill_fk FOREIGN KEY (character_skill_skill) REFERENCES skill_table(skill_id)
);

INSERT INTO character_skill_table(character_skill_character, character_skill_skill) VALUES(1, 1);
INSERT INTO character_skill_table(character_skill_character, character_skill_skill) VALUES(1, 2);

SELECT * FROM character_skill_table;

DROP TABLE character_skill_table;

-------------------------MONSTER_SKILL-------------------------

CREATE TABLE monster_skill_table (
    monster_skill_id NUMBER(10) GENERATED AS IDENTITY(START WITH 1 INCREMENT BY 1),
    monster_skill_monster NUMBER(10) NOT NULL,
    monster_skill_skill NUMBER(10) NOT NULL,
    CONSTRAINT monster_skill_pk PRIMARY KEY (monster_skill_id),
    CONSTRAINT monster_skill_monster_fk FOREIGN KEY (monster_skill_monster) REFERENCES monster_table(monster_id),
    CONSTRAINT monster_skill_skill_fk FOREIGN KEY (monster_skill_skill) REFERENCES skill_table(skill_id)
);

INSERT INTO monster_skill_table(monster_skill_monster, monster_skill_skill) VALUES(1, 1);
INSERT INTO monster_skill_table(monster_skill_monster, monster_skill_skill) VALUES(1, 2);

SELECT * FROM monster_skill_table;
SELECT count(*) FROM monster_skill_table;

DROP TABLE monster_skill_table;

-------------------------ITEM_TYPE-------------------------

CREATE TABLE item_type_table (
    item_type_id NUMBER(10) GENERATED AS IDENTITY(START WITH 1 INCREMENT BY 1),
    item_type_name VARCHAR2(30) NOT NULL,
    CONSTRAINT item_type_pk PRIMARY KEY (item_type_id)
);

INSERT INTO item_type_table(item_type_name) VALUES('ARMOR');
INSERT INTO item_type_table(item_type_name) VALUES('WEAPON');

SELECT * FROM item_type_table;

DROP TABLE item_type_table;

-------------------------ITEM-------------------------

CREATE TABLE item_table (
    item_id NUMBER(10) GENERATED AS IDENTITY(START WITH 1 INCREMENT BY 1),
    item_name VARCHAR2(30) NOT NULL,
    item_type NUMBER(10) NOT NULL,
    item_health NUMBER(10) NOT NULL,
    item_mana NUMBER(10) NOT NULL,
    item_power NUMBER(10) NOT NULL,
    item_speed NUMBER(10) NOT NULL,
    item_mind NUMBER(10) NOT NULL,
    item_blob BLOB DEFAULT EMPTY_BLOB(),
    CONSTRAINT item_pk PRIMARY KEY (item_id),
    CONSTRAINT item_type_fk FOREIGN KEY (item_type) REFERENCES item_type_table(item_type_id)
);

INSERT INTO item_table(item_name, item_type, item_health, item_mana, item_power, item_speed, item_mind) VALUES('GOLDEN CHESTPLATE', 1, 20, 5, 0, 0, 0);

SELECT * FROM item_table;

DROP TABLE item_table;

-------------------------CHARACTER_ITEM-------------------------

CREATE TABLE character_item_table (
    character_item_id NUMBER(10) GENERATED AS IDENTITY(START WITH 1 INCREMENT BY 1),
    character_item_character NUMBER(10) NOT NULL,
    character_item_item NUMBER(10) NOT NULL,
    CONSTRAINT character_item_pk PRIMARY KEY (character_item_id),
    CONSTRAINT character_item_character_fk FOREIGN KEY (character_item_character) REFERENCES character_table(character_id),
    CONSTRAINT character_item_item_fk FOREIGN KEY (character_item_item) REFERENCES item_table(item_id)
);

INSERT INTO character_item_table(character_item_character, character_item_item) VALUES(1, 1);
INSERT INTO character_item_table(character_item_character, character_item_item) VALUES(1, 2);

SELECT * FROM character_item_table;

DROP TABLE character_item_table;

-------------------------MONSTER_ITEM-------------------------

CREATE TABLE monster_item_table (
    monster_item_id NUMBER(10) GENERATED AS IDENTITY(START WITH 1 INCREMENT BY 1),
    monster_item_monster NUMBER(10) NOT NULL,
    monster_item_item NUMBER(10) NOT NULL,
    monster_item_chance NUMBER(10) NOT NULL,
    CONSTRAINT monster_item_pk PRIMARY KEY (monster_item_id),
    CONSTRAINT monster_item_monster_fk FOREIGN KEY (monster_item_monster) REFERENCES monster_table(monster_id),
    CONSTRAINT monster_item_item_fk FOREIGN KEY (monster_item_item) REFERENCES item_table(item_id)
);

INSERT INTO monster_item_table(monster_item_monster, monster_item_item) VALUES(1, 1);
INSERT INTO monster_item_table(monster_item_monster, monster_item_item) VALUES(1, 2);

DROP TABLE monster_item_table;