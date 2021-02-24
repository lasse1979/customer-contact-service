CREATE TABLE CustomerContact
(
  Id UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
  PersonalNumber VARCHAR(12),
  Email          VARCHAR(255),
  Street         VARCHAR(255),
  ZipCode        INT,
  Country        VARCHAR(7),
  PhoneNumber    VARCHAR(15)
)