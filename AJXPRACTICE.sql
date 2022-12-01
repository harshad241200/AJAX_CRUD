use practicemvc;

create table myuser(
id int primary key not null identity,
name varchar(200),
username varchar(200),
email varchar(200),
active char(1) default 'Y'
)



select * from myuser;
drop table myuser;