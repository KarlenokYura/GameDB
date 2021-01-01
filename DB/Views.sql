ALTER SESSION SET "_ORACLE_SCRIPT" = TRUE;

-------------------------USER & ROLE-------------------------

CREATE VIEW user_role_view AS SELECT user_table.user_login, user_table.user_password, user_table.user_name, user_table.user_surname, role_table.role_name
FROM user_table LEFT JOIN role_table ON user_table.user_role = role_table.role_id;

SELECT * FROM user_role_view;

DROP VIEW user_role_view;

-------------------------USER & CHARACTER & RACE & CLASS & LOCATION & LEVEL-------------------------

CREATE VIEW character_info_view AS SELECT user_table.user_login, character_table.character_name, race_table.race_name, class_table.class_name, location_table.location_name, character_table.character_level,
character_table.character_exp, character_table.character_health, character_table.character_max_health, character_table.character_mana, character_table.character_max_mana,
character_table.character_power, character_table.character_speed, character_table.character_mind
FROM character_table INNER JOIN user_table ON character_table.character_user = user_table.user_id
LEFT JOIN race_table ON character_table.character_race = race_table.race_id
LEFT JOIN class_table ON character_table.character_class = class_table.class_id
LEFT JOIN location_table ON character_table.character_location = location_table.location_id;

SELECT * FROM character_info_view;

DROP VIEW character_info_view;

set timing on;

-------------------------MONSTER & RACE & CLASS & LOCATION & LEVEL-------------------------

CREATE VIEW monster_info_view AS SELECT monster_table.monster_name, race_table.race_name, class_table.class_name, location_table.location_name, monster_table.monster_level,
monster_table.monster_health, monster_table.monster_max_health, monster_table.monster_mana, monster_table.monster_max_mana,
monster_table.monster_power, monster_table.monster_speed, monster_table.monster_mind
FROM monster_table LEFT JOIN race_table ON monster_table.monster_race = race_table.race_id
LEFT JOIN class_table ON monster_table.monster_class = class_table.class_id
LEFT JOIN location_table ON monster_table.monster_location = location_table.location_id;

SELECT * FROM monster_info_view;

DROP VIEW monster_info_view;

-------------------------NPC & FROPESSION & LOCATION-------------------------

CREATE VIEW npc_info_view AS SELECT npc_table.npc_name, race_table.race_name, profession_table.profession_name, location_table.location_name, npc_table.npc_level
FROM npc_table LEFT JOIN race_table ON npc_table.npc_race = race_table.race_id
LEFT JOIN profession_table ON npc_table.npc_profession = profession_table.profession_id
LEFT JOIN location_table ON npc_table.npc_location = location_table.location_id;

SELECT * FROM npc_info_view;

DROP VIEW npc_info_view;

-------------------------CHARACTER & RACE & CLASS & SKILL & TYPE-------------------------

CREATE VIEW character_skill_info_view AS SELECT character_table.character_name, skill_table.skill_name, race_table.race_name, class_table.class_name, skill_type_table.skill_type_name,
skill_table.skill_health, skill_table.skill_mana, skill_table.skill_level
FROM character_skill_table LEFT JOIN character_table ON character_skill_table.character_skill_character = character_table.character_id
LEFT JOIN skill_table ON character_skill_table.character_skill_skill = skill_table.skill_id
LEFT JOIN race_table ON skill_table.skill_race = race_table.race_id
LEFT JOIN class_table ON skill_table.skill_class = class_table.class_id
LEFT JOIN skill_type_table ON skill_table.skill_type = skill_type_table.skill_type_id;

SELECT * FROM character_skill_info_view;

DROP VIEW character_skill_info_view;

-------------------------MONSTER & RACE & CLASS & SKILL & TYPE-------------------------

CREATE VIEW monster_skill_info_view AS SELECT monster_table.monster_name, skill_table.skill_name, race_table.race_name, class_table.class_name, skill_type_table.skill_type_name, 
skill_table.skill_health, skill_table.skill_mana, skill_table.skill_level
FROM monster_skill_table LEFT JOIN monster_table ON monster_skill_table.monster_skill_monster = monster_table.monster_id
LEFT JOIN skill_table ON monster_skill_table.monster_skill_skill = skill_table.skill_id
LEFT JOIN race_table ON skill_table.skill_race = race_table.race_id
LEFT JOIN class_table ON skill_table.skill_class = class_table.class_id
LEFT JOIN skill_type_table ON skill_table.skill_type = skill_type_table.skill_type_id;

SELECT * FROM monster_skill_info_view;

DROP VIEW monster_skill_info_view;

-------------------------CHARACTER & ITEM & TYPE-------------------------

CREATE VIEW character_item_info_view AS SELECT character_table.character_name, item_table.item_name, item_type_table.item_type_name,
item_table.item_health, item_table.item_mana, item_table.item_power, item_table.item_speed, item_table.item_mind 
FROM character_item_table LEFT JOIN character_table ON character_item_table.character_item_character = character_table.character_id
LEFT JOIN item_table ON character_item_table.character_item_item = item_table.item_id
LEFT JOIN item_type_table ON item_table.item_type = item_type_table.item_type_id;

SELECT * FROM character_item_info_view;

DROP VIEW character_item_info_view;

-------------------------MONSTER & ITEM & TYPE-------------------------

CREATE VIEW monster_item_info_view AS SELECT monster_table.monster_name, item_table.item_name, item_type_table.item_type_name,
item_table.item_health, item_table.item_mana, item_table.item_power, item_table.item_speed, item_table.item_mind, monster_item_table.monster_item_chance
FROM monster_item_table LEFT JOIN monster_table ON monster_item_table.monster_item_monster = monster_table.monster_id
LEFT JOIN item_table ON monster_item_table.monster_item_item = item_table.item_id
LEFT JOIN item_type_table ON item_table.item_type = item_type_table.item_type_id;

SELECT * FROM monster_item_info_view;

DROP VIEW monster_item_info_view;