select * from QAs
select * from SubDomains
select * from Advertisments

insert into QAs(Question,Answer,SubDomain_ID,Advertisment_ID)
values('What is a class','A class is bla bla',1,2),
      ('What is an object','An object is bla bla',1,2);