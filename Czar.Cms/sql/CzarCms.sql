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
   'Manager��̨����Ա',
   'user', @CurrentUser, 'table', 'Manager'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������ID',
   'user', @CurrentUser, 'table', 'Manager', 'column', 'MID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�û���',
   'user', @CurrentUser, 'table', 'Manager', 'column', 'LoginName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'Manager', 'column', 'Password'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ǳ�',
   'user', @CurrentUser, 'table', 'Manager', 'column', 'UserName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ͷ��',
   'user', @CurrentUser, 'table', 'Manager', 'column', 'HeadImg'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ֻ�����',
   'user', @CurrentUser, 'table', 'Manager', 'column', 'Mobile'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ɫID',
   'user', @CurrentUser, 'table', 'Manager', 'column', 'RoleID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����ַ',
   'user', @CurrentUser, 'table', 'Manager', 'column', 'Email'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��¼����',
   'user', @CurrentUser, 'table', 'Manager', 'column', 'LoginCount'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���һ�ε�¼IP',
   'user', @CurrentUser, 'table', 'Manager', 'column', 'LastLoginIP'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���һ�ε�¼ʱ��',
   'user', @CurrentUser, 'table', 'Manager', 'column', 'LastLoginTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'Manager', 'column', 'Opertor'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ʱ��',
   'user', @CurrentUser, 'table', 'Manager', 'column', 'UpdateTIME'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ƿ�ɾ��',
   'user', @CurrentUser, 'table', 'Manager', 'column', 'IsDel'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ƿ�����',
   'user', @CurrentUser, 'table', 'Manager', 'column', 'IsLock'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ע',
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
   '��̨����˵�',
   'user', @CurrentUser, 'table', 'ManagerMenu'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�˵�ID',
   'user', @CurrentUser, 'table', 'ManagerMenu', 'column', 'MenuID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���˵�ID',
   'user', @CurrentUser, 'table', 'ManagerMenu', 'column', 'PID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�˵�����',
   'user', @CurrentUser, 'table', 'ManagerMenu', 'column', 'MenuName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ʾ����',
   'user', @CurrentUser, 'table', 'ManagerMenu', 'column', 'ShowName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ͼ���ַ',
   'user', @CurrentUser, 'table', 'ManagerMenu', 'column', 'ImgUrl'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ӵ�ַ',
   'user', @CurrentUser, 'table', 'ManagerMenu', 'column', 'LinkUrl'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����ֶ�',
   'user', @CurrentUser, 'table', 'ManagerMenu', 'column', 'OrderBy'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����Ȩ��',
   'user', @CurrentUser, 'table', 'ManagerMenu', 'column', 'OperPower'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'ManagerMenu', 'column', 'Opertor'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ʱ��',
   'user', @CurrentUser, 'table', 'ManagerMenu', 'column', 'UpdateTIME'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ƿ�ɾ��',
   'user', @CurrentUser, 'table', 'ManagerMenu', 'column', 'IsDel'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ע',
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
   '��ɫID',
   'user', @CurrentUser, 'table', 'ManagerRole', 'column', 'RoleID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������ID',
   'user', @CurrentUser, 'table', 'ManagerRole', 'column', 'MID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ɫ����',
   'user', @CurrentUser, 'table', 'ManagerRole', 'column', 'RoleType'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ɫ����',
   'user', @CurrentUser, 'table', 'ManagerRole', 'column', 'RoleName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ƿ�ϵͳĬ��',
   'user', @CurrentUser, 'table', 'ManagerRole', 'column', 'IsDefault'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'ManagerRole', 'column', 'Opertor'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ʱ��',
   'user', @CurrentUser, 'table', 'ManagerRole', 'column', 'UpdateTIME'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ƿ�ɾ��',
   'user', @CurrentUser, 'table', 'ManagerRole', 'column', 'IsDel'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ע',
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
   '������־',
   'user', @CurrentUser, 'table', 'OperLog'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'OperLog', 'column', 'LogID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Man_������ID',
   'user', @CurrentUser, 'table', 'OperLog', 'column', 'Man_MID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'OperLog', 'column', 'OperType'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������ID',
   'user', @CurrentUser, 'table', 'OperLog', 'column', 'MID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'OperLog', 'column', 'Opertor'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'OperLog', 'column', 'OperTime'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����IP',
   'user', @CurrentUser, 'table', 'OperLog', 'column', 'OperIP'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����������',
   'user', @CurrentUser, 'table', 'OperLog', 'column', 'OpertorName'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ע',
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
   '��ɫȨ�ޱ�',
   'user', @CurrentUser, 'table', 'RolePower'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'RolePower', 'column', 'PowerID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Man_��ɫID',
   'user', @CurrentUser, 'table', 'RolePower', 'column', 'Man_RoleID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��̨��_�˵�ID',
   'user', @CurrentUser, 'table', 'RolePower', 'column', 'Man_MenuID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ɫID',
   'user', @CurrentUser, 'table', 'RolePower', 'column', 'RoleID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�˵�ID',
   'user', @CurrentUser, 'table', 'RolePower', 'column', 'MenuID'
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
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

