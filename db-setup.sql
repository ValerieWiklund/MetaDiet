CREATE TABLE users
(
  id VARCHAR(255) NOT NULL,
  username VARCHAR(255) NOT NULL,
  email VARCHAR(255) NOT NULL,
  dob DATE,
  startdate DATE NOT NULL,
  height DECIMAL,
  startweight INT NOT NULL,
  goalweight INT NOT NULL,
  gender CHAR(1),
  hash VARCHAR(255) NOT NULL,
  PRIMARY KEY (id),
  UNIQUE
  KEY email
  (email)
);

--   CREATE TABLE vaults
--   (
--     id int NOT NULL
--     AUTO_INCREMENT,
--     name VARCHAR
--     (255) NOT NULL,
--     description VARCHAR
--     (255) NOT NULL,
--     userId VARCHAR
--     (255),
--     INDEX userId
--     (userId),
--     FOREIGN KEY
--     (userId)
--         REFERENCES users
--     (id)
--         ON
--     DELETE CASCADE,  
--     PRIMARY KEY (id)
--     );

-- CREATE TABLE foods
-- (
--   id int NOT NULL
--   AUTO_INCREMENT,
--   name VARCHAR
--   (255) NOT NULL,
--   description VARCHAR
--   (255) NOT NULL,
--   category VARCHAR
--   (255) NOT NULL,
--   phase1 TINYINT NOT NULL,
--   phase2 TINYINT NOT NULL,
--   phase3 TINYINT NOT NULL,
--   servingnum INT NOT NULL,
--   sizedescription VARCHAR
--   (255) NOT NULL,
--   INDEX
--   (phase1, phase2, phase3),         
--   PRIMARY KEY
--   (id)
--   );

--       CREATE TABLE vaultkeeps
--       (
--         id int NOT NULL
--         AUTO_INCREMENT,
--     vaultId int NOT NULL,
--     keepId int NOT NULL,
--     userId VARCHAR
--         (255) NOT NULL,

--     PRIMARY KEY
--         (id),
--     INDEX
--         (vaultId, keepId),
--     INDEX
--         (userId),

--     FOREIGN KEY
--         (userId)
--         REFERENCES users
--         (id)
--         ON
--         DELETE CASCADE,

--     FOREIGN KEY (vaultId)
--         REFERENCES vaults
--         (id)
--         ON
--         DELETE CASCADE,

--     FOREIGN KEY (keepId)
--         REFERENCES keeps
--         (id)
--         ON
--         DELETE CASCADE
-- )


-- -- USE THIS LINE FOR GET KEEPS BY VAULTID
-- SELECT * FROM vaultkeeps vk
-- INNER JOIN keeps k ON k.id = vk.keepId 
-- WHERE (vaultId = @vaultId AND vk.userId = @userId) 



-- -- USE THIS TO CLEAN OUT YOUR DATABASE
-- DROP TABLE IF EXISTS vaultkeeps;
-- DROP TABLE IF EXISTS vaults;
-- DROP TABLE IF EXISTS keeps;
-- DROP TABLE IF EXISTS users;
-- 