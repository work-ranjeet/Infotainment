-------------------------------Groups-------------------------
INSERT INTO Groups (GroupID, GroupType, GroupDetails, IsActive)
VALUES (1, 'SuperAdmin', 'Super Admin users', 1)

INSERT INTO Groups (GroupID, GroupType, GroupDetails, IsActive)
VALUES (2, 'Admin', 'Admin users', 1)

INSERT INTO Groups (GroupID, GroupType, GroupDetails, IsActive)
VALUES (3, 'General', 'General users', 1)

--------------Usrs ------------------------------------------
INSERT INTO Users (FName, MName, LName, Gender, Dob, Age, MariedSatus, IsActive, IsNew)
VALUES ('Ranjeet', '', 'Kumar', 'M', '1983-10-17', (select FLOOR(DATEDIFF(day, '1983-10-17', getDate()) / 365.25)), 0, 1, 0)

--------------------ImageType---------------------------
insert into ImageType(ImageType, ImageDesc) values(1, 'Top News Image')
