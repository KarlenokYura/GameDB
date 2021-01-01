ALTER SESSION SET "_ORACLE_SCRIPT" = TRUE;

-------------------------EXP_TRIGGER-------------------------

CREATE VIEW character_view AS SELECT * FROM character_table;
SELECT * FROM character_view;
DROP VIEW character_view;

CREATE OR REPLACE TRIGGER exp_trigger
INSTEAD OF UPDATE ON character_view
BEGIN
    IF (:new.character_exp <= 4) THEN UPDATE character_table SET character_exp = :new.character_exp, character_level = 1 WHERE character_name = :new.character_name;
    ELSIF (:new.character_exp > 4 AND :new.character_exp <= 8) THEN UPDATE character_table SET character_exp = :new.character_exp, character_level = 2 WHERE character_name = :new.character_name;
    ELSIF (:new.character_exp > 8 AND :new.character_exp <= 16) THEN UPDATE character_table SET character_exp = :new.character_exp, character_level = 3 WHERE character_name = :new.character_name;
    ELSIF (:new.character_exp > 16 AND :new.character_exp <= 32) THEN UPDATE character_table SET character_exp = :new.character_exp, character_level = 4 WHERE character_name = :new.character_name;
    ELSIF (:new.character_exp > 32 AND :new.character_exp <= 64) THEN UPDATE character_table SET character_exp = :new.character_exp, character_level = 5 WHERE character_name = :new.character_name;
    ELSIF (:new.character_exp > 64 AND :new.character_exp <= 128) THEN UPDATE character_table SET character_exp = :new.character_exp, character_level = 6 WHERE character_name = :new.character_name;
    ELSIF (:new.character_exp > 128 AND :new.character_exp <= 256) THEN UPDATE character_table SET character_exp = :new.character_exp, character_level = 7 WHERE character_name = :new.character_name;
    ELSIF (:new.character_exp > 256 AND :new.character_exp <= 512) THEN UPDATE character_table SET character_exp = :new.character_exp, character_level = 8 WHERE character_name = :new.character_name;
    ELSIF (:new.character_exp > 512 AND :new.character_exp <= 1024) THEN UPDATE character_table SET character_exp = :new.character_exp, character_level = 9 WHERE character_name = :new.character_name;
    ELSIF (:new.character_exp > 1024 AND :new.character_exp <= 2048) THEN UPDATE character_table SET character_exp = :new.character_exp, character_level = 10 WHERE character_name = :new.character_name;
    ELSIF (:new.character_exp > 2048 AND :new.character_exp <= 4096) THEN UPDATE character_table SET character_exp = :new.character_exp, character_level = 11 WHERE character_name = :new.character_name;
    ELSIF (:new.character_exp > 4096 AND :new.character_exp <= 8192) THEN UPDATE character_table SET character_exp = :new.character_exp, character_level = 12 WHERE character_name = :new.character_name;
    ELSIF (:new.character_exp > 8192 AND :new.character_exp <= 16384) THEN UPDATE character_table SET character_exp = :new.character_exp, character_level = 13 WHERE character_name = :new.character_name;
    ELSIF (:new.character_exp > 16384 AND :new.character_exp <= 32768) THEN UPDATE character_table SET character_exp = :new.character_exp, character_level = 14 WHERE character_name = :new.character_name;
    ELSIF (:new.character_exp > 32768 AND :new.character_exp <= 65536) THEN UPDATE character_table SET character_exp = :new.character_exp, character_level = 15 WHERE character_name = :new.character_name;
    ELSIF (:new.character_exp > 65536 AND :new.character_exp <= 131072) THEN UPDATE character_table SET character_exp = :new.character_exp, character_level = 16 WHERE character_name = :new.character_name;
    ELSIF (:new.character_exp > 131072 AND :new.character_exp <= 262144) THEN UPDATE character_table SET character_exp = :new.character_exp, character_level = 17 WHERE character_name = :new.character_name;
    ELSIF (:new.character_exp > 262144 AND :new.character_exp <= 524288) THEN UPDATE character_table SET character_exp = :new.character_exp, character_level = 18 WHERE character_name = :new.character_name;
    ELSIF (:new.character_exp > 524288 AND :new.character_exp <= 1048576) THEN UPDATE character_table SET character_exp = :new.character_exp, character_level = 19 WHERE character_name = :new.character_name;
    ELSE UPDATE character_table SET character_exp = :new.character_exp, character_level = 20 WHERE character_name = :new.character_name;
    END IF;
    
    UPDATE character_table SET character_health = (35 + :new.character_health, 
                               character_max_health = (35 + (character_table.character_level * 5)),
                               character_mana = (15 + (character_table.character_level * 5)),
                               character_max_mana = (15 + (character_table.character_level * 5)),
                               character_power = (3 + (character_table.character_level * 2)),
                               character_speed = (2 + character_table.character_level),
                               character_mind = (2 + character_table.character_level)
                               WHERE character_name = :new.character_name;       
                               
    character_skill(:new.character_name);
END;

SELECT * FROM character_view;

UPDATE character_view SET character_exp = 1024 WHERE character_name = 'DEMONMAGE';
COMMIT;

DROP TRIGGER exp_trigger;