﻿select COUNT(*) from [User]

select * from UserRole

select * from [Role]

select * from dbo.[User]

select * from RolePermission  where RoleID in (201)

delete dbo.RolePermission where RoleID=201 and PermissionID=3

insert into dbo.RolePermission(RoleID,PermissionID)values(201,3)

select * from Permission

select * from EntityPermission

select * from dbo.Navigate

print '设置djlnet role 1, demotest role2准备测试'

select * from dbo.UserRole where UserID=1

insert into dbo.UserRole([UserID],RoleID) values(1,1)
insert into dbo.UserRole([UserID],RoleID) values(2,202)

insert into dbo.RolePermission
select 1,a.ID
from dbo.Permission as a