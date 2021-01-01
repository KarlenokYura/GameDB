ALTER SESSION SET "_ORACLE_SCRIPT" = TRUE;

-------------------------GAMEDBADMIN-------------------------

CREATE USER GameDBAdmin
IDENTIFIED BY Pa$$w0rd 
DEFAULT TABLESPACE Users 
QUOTA UNLIMITED ON Users;

GRANT CONNECT TO GameDBAdmin;
GRANT CREATE TABLE TO GameDBAdmin;
GRANT CREATE SEQUENCE TO GameDBAdmin;
GRANT CREATE VIEW TO GameDBAdmin;
GRANT CREATE INDEXTYPE TO GameDBAdmin;
GRANT CREATE PROCEDURE TO GameDBAdmin;
GRANT CREATE TRIGGER TO GameDBAdmin;
GRANT CREATE SESSION TO GameDBAdmin;
GRANT CREATE JOB TO GameDBAdmin;

GRANT EXECUTE ON sys.dbms_crypto TO GameDBAdmin;

COMMIT;

--GRANT EXECUTE ON GameDBAdmin.create_user TO GameDBAdmin;
--GRANT EXECUTE ON GameDBAdmin.drop_user TO GameDBAdmin;

DROP USER GameDBAdmin;

-------------------------GAMEDBUSER-------------------------

CREATE USER GameDBUser
IDENTIFIED BY Pa$$w0rd 
DEFAULT TABLESPACE Users 
QUOTA UNLIMITED ON Users;

GRANT CREATE SESSION TO GameDBUser;

GRANT SELECT ON GameDBAdmin.race_table TO GameDBUser;
GRANT SELECT ON GameDBAdmin.class_table TO GameDBUser;
GRANT SELECT ON GameDBAdmin.location_table TO GameDBUser;
GRANT SELECT ON GameDBAdmin.character_table TO GameDBUser;
GRANT SELECT ON GameDBAdmin.monster_table TO GameDBUser;
GRANT SELECT ON GameDBAdmin.npc_table TO GameDBUser;
GRANT SELECT ON GameDBAdmin.skill_table TO GameDBUser;
GRANT SELECT ON GameDBAdmin.item_table TO GameDBUser;

GRANT SELECT ON GameDBAdmin.user_role_view TO GameDBUser;
GRANT SELECT ON GameDBAdmin.character_info_view TO GameDBUser;
GRANT SELECT ON GameDBAdmin.monster_info_view TO GameDBUser;
GRANT SELECT ON GameDBAdmin.npc_info_view TO GameDBUser;
GRANT SELECT ON GameDBAdmin.character_skill_info_view TO GameDBUser;
GRANT SELECT ON GameDBAdmin.monster_skill_info_view TO GameDBUser;
GRANT SELECT ON GameDBAdmin.character_item_info_view TO GameDBUser;
GRANT SELECT ON GameDBAdmin.monster_item_info_view TO GameDBUser;
GRANT SELECT ON GameDBAdmin.character_view TO GameDBUser;
GRANT UPDATE ON GameDBAdmin.character_view TO GameDBUser;

GRANT EXECUTE ON GameDBAdmin.register_user TO GameDBUser;
GRANT EXECUTE ON GameDBAdmin.log_in_user TO GameDBUser;
GRANT EXECUTE ON GameDBAdmin.search_user TO GameDBUser;
GRANT EXECUTE ON GameDBAdmin.update_user_login TO GameDBUser;
GRANT EXECUTE ON GameDBAdmin.update_user_password TO GameDBUser;
GRANT EXECUTE ON GameDBAdmin.update_user_name TO GameDBUser;
GRANT EXECUTE ON GameDBAdmin.update_user_surname TO GameDBUser;
GRANT EXECUTE ON GameDBAdmin.delete_user TO GameDBUser;
GRANT EXECUTE ON GameDBAdmin.check_role TO GameDBUser;
GRANT EXECUTE ON GameDBAdmin.create_character TO GameDBUser;
GRANT EXECUTE ON GameDBAdmin.change_character TO GameDBUser;
GRANT EXECUTE ON GameDBAdmin.delete_character_by_user TO GameDBUser;
GRANT EXECUTE ON GameDBAdmin.delete_skill TO GameDBUser;
GRANT EXECUTE ON GameDBAdmin.delete_item TO GameDBUser;
GRANT EXECUTE ON GameDBAdmin.change_location TO GameDBUser;
GRANT EXECUTE ON GameDBAdmin.race_location TO GameDBUser;
GRANT EXECUTE ON GameDBAdmin.character_limit TO GameDBUser;
GRANT EXECUTE ON GameDBAdmin.change_location TO GameDBUser;
GRANT EXECUTE ON GameDBAdmin.character_skill TO GameDBUser;
GRANT EXECUTE ON GameDBAdmin.character_skill_load TO GameDBUser;
GRANT EXECUTE ON GameDBAdmin.drop_item TO GameDBUser;
GRANT EXECUTE ON GameDBAdmin.start_job TO GameDBUser;
GRANT EXECUTE ON GameDBAdmin.set_health_mana TO GameDBUser;

COMMIT;

DROP USER GameDBUser;