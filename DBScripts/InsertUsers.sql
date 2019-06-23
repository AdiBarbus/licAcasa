Insert Into Users(UserName,Email,Password,ConfirmPassword,Phone,University,RoleId)
Values('Ion','ion@yahoo.com','test','test',1234,'UBB',2),
	  ('Softvision','softvision@gmail.com','test','test',5533,null,3),
	  ('admin','admin@admin','admin','admin',null,null,1);

select * from Users

select Users.FirstName, Users.Email, Addresses.City
from Users
inner join Addresses On Users.ID = Addresses.UserID

