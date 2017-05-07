select * from [User]

select * from UserRole

select * from [Role]

select * from RolePermission  where RoleID in (201,202)

select * from Permission

select * from EntityPermission

print '设置djlnet role 1, demotest role2准备测试'

insert into dbo.UserRole([UserID],RoleID) values(1,201)
insert into dbo.UserRole([UserID],RoleID) values(2,202)

insert into dbo.RolePermission
select 202,a.ID
from dbo.Permission as a
where a.ID not in (12)