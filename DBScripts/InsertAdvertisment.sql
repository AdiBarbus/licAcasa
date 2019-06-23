select * from Advertises
select * from Users
select * from SubDomains

insert into Advertises(Title,Details,CreateDate,EndDate,City,DomainId,UserId,SubDomainId)
values ('Javascript','Javascript internship',GETDATE(),'2019-12-19','Cluj-Napoca',1,2,4),
	   ('C','C ii pt fraieri',GETDATE(),'2019-10-19','Timisoara',1,2,1),
	   ('Toj','Detalii detalii',GETDATE(),'2020-06-19','Crasna',1,2,1),
	   ('Toj','Training on the job',GETDATE(),'2020-12-19','Cluj-Napoca',1,2,1);