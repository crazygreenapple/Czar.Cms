/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     2019/3/6 16:03:13                            */
/*==============================================================*/


if exists (select 1
            from  sysobjects
           where  id = object_id('Manager')
            and   type = 'U')
   drop table Manager
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ManagerMenu')
            and   type = 'U')
   drop table ManagerMenu
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ManagerRole')
            and   name  = 'RoleID_FK'
            and   indid > 0
            and   indid < 255)
   drop index ManagerRole.RoleID_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ManagerRole')
            and   type = 'U')
   drop table ManagerRole
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('OperLog')
            and   name  = 'MID_FK'
            and   indid > 0
            and   indid < 255)
   drop index OperLog.MID_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('OperLog')
            and   type = 'U')
   drop table OperLog
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('RolePower')
            and   name  = 'RoleID2_FK'
            and   indid > 0
            and   indid < 255)
   drop index RolePower.RoleID2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('RolePower')
            and   name  = 'MenuID_FK'
            and   indid > 0
            and   indid < 255)
   drop index RolePower.MenuID_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('RolePower')
            and   type = 'U')
   drop table RolePower
go

/*==============================================================*/
/* Table: Manager                                               */
/*==============================================================*/
create table Manager (
   MID                  int                  not null,
   LoginName            varchar(12)          null,
   Password             varchar(128)         null,
   UserName             varchar(128)         null,
   HeadImg              varchar(255)         null,
   Mobile               varchar(16)          null,
   RoleID               int                  null,
   Email                varchar(16)          null,
   LoginCount           int                  null,
   LastLoginIP          varchar(64)          null,
   LastLoginTime        datetime             null,
   Opertor              int                  null,
   UpdateTIME           datetime             null,
   IsDel                bit                  null,
   IsLock               bit                  null,
   Remark               varchar(200)         null,
   constraint PK_MANAGER primary key nonclustered (MID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Manager后台管理员',
   'user', @CurrentUser, 'table', 'Manager'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '操作人ID',
   'user', @CurrentUser, 'table', 'Manager', 'column', 'MID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户名',
   'user', @CurrentUser, 'table', 'Manager', 'column', 'LoginName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '密码',
   'user', @CurrentUser, 'table', 'Manager', 'column', 'Password'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '昵称',
   'user', @CurrentUser, 'table', 'Manager', 'column', 'UserName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '头像',
   'user', @CurrentUser, 'table', 'Manager', 'column', 'HeadImg'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '手机号码',
   'user', @CurrentUser, 'table', 'Manager', 'column', 'Mobile'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '角色ID',
   'user', @CurrentUser, 'table', 'Manager', 'column', 'RoleID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '邮箱地址',
   'user', @CurrentUser, 'table', 'Manager', 'column', 'Email'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '登录次数',
   'user', @CurrentUser, 'table', 'Manager', 'column', 'LoginCount'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最后一次登录IP',
   'user', @CurrentUser, 'table', 'Manager', 'column', 'LastLoginIP'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最后一次登录时间',
   'user', @CurrentUser, 'table', 'Manager', 'column', 'LastLoginTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '操作人',
   'user', @CurrentUser, 'table', 'Manager', 'column', 'Opertor'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '添加时间',
   'user', @CurrentUser, 'table', 'Manager', 'column', 'UpdateTIME'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否删除',
   'user', @CurrentUser, 'table', 'Manager', 'column', 'IsDel'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否锁定',
   'user', @CurrentUser, 'table', 'Manager', 'column', 'IsLock'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'Manager', 'column', 'Remark'
go

/*==============================================================*/
/* Table: ManagerMenu                                           */
/*==============================================================*/
create table ManagerMenu (
   MenuID               int                  not null,
   PID                  int                  null,
   MenuName             varchar(32)          null,
   ShowName             varchar(128)         null,
   ImgUrl               varchar(255)         null,
   LinkUrl              varchar(128)         null,
   OrderBy              int                  null,
   OperPower            varchar(128)         null,
   Opertor              int                  null,
   UpdateTIME           datetime             null,
   IsDel                bit                  null,
   Remark               varchar(200)         null,
   constraint PK_MANAGERMENU primary key nonclustered (MenuID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '后台管理菜单',
   'user', @CurrentUser, 'table', 'ManagerMenu'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '菜单ID',
   'user', @CurrentUser, 'table', 'ManagerMenu', 'column', 'MenuID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '父菜单ID',
   'user', @CurrentUser, 'table', 'ManagerMenu', 'column', 'PID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '菜单名称',
   'user', @CurrentUser, 'table', 'ManagerMenu', 'column', 'MenuName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '显示名称',
   'user', @CurrentUser, 'table', 'ManagerMenu', 'column', 'ShowName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '图标地址',
   'user', @CurrentUser, 'table', 'ManagerMenu', 'column', 'ImgUrl'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '链接地址',
   'user', @CurrentUser, 'table', 'ManagerMenu', 'column', 'LinkUrl'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '排序字段',
   'user', @CurrentUser, 'table', 'ManagerMenu', 'column', 'OrderBy'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '操作权限',
   'user', @CurrentUser, 'table', 'ManagerMenu', 'column', 'OperPower'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '操作人',
   'user', @CurrentUser, 'table', 'ManagerMenu', 'column', 'Opertor'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '添加时间',
   'user', @CurrentUser, 'table', 'ManagerMenu', 'column', 'UpdateTIME'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否删除',
   'user', @CurrentUser, 'table', 'ManagerMenu', 'column', 'IsDel'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'ManagerMenu', 'column', 'Remark'
go

/*==============================================================*/
/* Table: ManagerRole                                           */
/*==============================================================*/
create table ManagerRole (
   RoleID               int                  not null,
   MID                  int                  null,
   RoleType             int                  null,
   RoleName             varchar(12)          null,
   IsDefault            bit                  null,
   Opertor              int                  null,
   UpdateTIME           datetime             null,
   IsDel                bit                  null,
   Remark               varchar(200)         null,
   constraint PK_MANAGERROLE primary key nonclustered (RoleID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ManagerRole',
   'user', @CurrentUser, 'table', 'ManagerRole'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '角色ID',
   'user', @CurrentUser, 'table', 'ManagerRole', 'column', 'RoleID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '操作人ID',
   'user', @CurrentUser, 'table', 'ManagerRole', 'column', 'MID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '角色类型',
   'user', @CurrentUser, 'table', 'ManagerRole', 'column', 'RoleType'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '角色名称',
   'user', @CurrentUser, 'table', 'ManagerRole', 'column', 'RoleName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否系统默认',
   'user', @CurrentUser, 'table', 'ManagerRole', 'column', 'IsDefault'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '操作人',
   'user', @CurrentUser, 'table', 'ManagerRole', 'column', 'Opertor'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '添加时间',
   'user', @CurrentUser, 'table', 'ManagerRole', 'column', 'UpdateTIME'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否删除',
   'user', @CurrentUser, 'table', 'ManagerRole', 'column', 'IsDel'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'ManagerRole', 'column', 'Remark'
go

/*==============================================================*/
/* Index: RoleID_FK                                             */
/*==============================================================*/
create index RoleID_FK on ManagerRole (
MID ASC
)
go

/*==============================================================*/
/* Table: OperLog                                               */
/*==============================================================*/
create table OperLog (
   LogID                int                  not null,
   Man_MID              int                  null,
   OperType             varchar(128)         null,
   MID                  int                  null,
   Opertor              int                  null,
   OperTime             datetime             null,
   OperIP               varchar(12)          null,
   OpertorName          varchar(12)          null,
   Remark               varchar(200)         null,
   constraint PK_OPERLOG primary key nonclustered (LogID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '操作日志',
   'user', @CurrentUser, 'table', 'OperLog'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '主键',
   'user', @CurrentUser, 'table', 'OperLog', 'column', 'LogID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Man_操作人ID',
   'user', @CurrentUser, 'table', 'OperLog', 'column', 'Man_MID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '操作类型',
   'user', @CurrentUser, 'table', 'OperLog', 'column', 'OperType'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '操作人ID',
   'user', @CurrentUser, 'table', 'OperLog', 'column', 'MID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '操作人',
   'user', @CurrentUser, 'table', 'OperLog', 'column', 'Opertor'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '操作时间',
   'user', @CurrentUser, 'table', 'OperLog', 'column', 'OperTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '操作IP',
   'user', @CurrentUser, 'table', 'OperLog', 'column', 'OperIP'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '操作人名称',
   'user', @CurrentUser, 'table', 'OperLog', 'column', 'OpertorName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'OperLog', 'column', 'Remark'
go

/*==============================================================*/
/* Index: MID_FK                                                */
/*==============================================================*/
create index MID_FK on OperLog (
Man_MID ASC
)
go

/*==============================================================*/
/* Table: RolePower                                             */
/*==============================================================*/
create table RolePower (
   PowerID              int                  not null,
   Man_RoleID           int                  null,
   Man_MenuID           int                  null,
   RoleID               int                  null,
   MenuID               int                  null,
   OperType             varchar(128)         null,
   constraint PK_ROLEPOWER primary key nonclustered (PowerID)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '角色权限表',
   'user', @CurrentUser, 'table', 'RolePower'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '主键',
   'user', @CurrentUser, 'table', 'RolePower', 'column', 'PowerID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Man_角色ID',
   'user', @CurrentUser, 'table', 'RolePower', 'column', 'Man_RoleID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '后台管_菜单ID',
   'user', @CurrentUser, 'table', 'RolePower', 'column', 'Man_MenuID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '角色ID',
   'user', @CurrentUser, 'table', 'RolePower', 'column', 'RoleID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '菜单ID',
   'user', @CurrentUser, 'table', 'RolePower', 'column', 'MenuID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '操作类型',
   'user', @CurrentUser, 'table', 'RolePower', 'column', 'OperType'
go

/*==============================================================*/
/* Index: MenuID_FK                                             */
/*==============================================================*/
create index MenuID_FK on RolePower (
Man_MenuID ASC
)
go

/*==============================================================*/
/* Index: RoleID2_FK                                            */
/*==============================================================*/
create index RoleID2_FK on RolePower (
Man_RoleID ASC
)
go

