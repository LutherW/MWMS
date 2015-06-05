/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2012                    */
/* Created on:     2015-06-05 22:23:55                          */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('AllotGoods') and o.name = 'FK_ALLOTGOO_ASSOCIATI_GOODS')
alter table AllotGoods
   drop constraint FK_ALLOTGOO_ASSOCIATI_GOODS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('AllotGoods') and o.name = 'FK_ALLOTGOO_ASSOCIATI_STOREING')
alter table AllotGoods
   drop constraint FK_ALLOTGOO_ASSOCIATI_STOREING
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('AllotGoods') and o.name = 'FK_ALLOTGOO_ASSOCIATI_ALLOTORD')
alter table AllotGoods
   drop constraint FK_ALLOTGOO_ASSOCIATI_ALLOTORD
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('AllotGoods') and o.name = 'FK_ALLOTGOO_ASSOCIATI_STOREINO')
alter table AllotGoods
   drop constraint FK_ALLOTGOO_ASSOCIATI_STOREINO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('AllotOrder') and o.name = 'FK_ALLOTORD_ASSOCIATI_STORE')
alter table AllotOrder
   drop constraint FK_ALLOTORD_ASSOCIATI_STORE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('AllotOrder') and o.name = 'FK_ALLOTORD_ASSOCIATI_STORE')
alter table AllotOrder
   drop constraint FK_ALLOTORD_ASSOCIATI_STORE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Attach') and o.name = 'FK_ATTACH_ASSOCIATI_STOREING')
alter table Attach
   drop constraint FK_ATTACH_ASSOCIATI_STOREING
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CheckCost') and o.name = 'FK_CHECKCOS_ASSOCIATI_CHECKREC')
alter table CheckCost
   drop constraint FK_CHECKCOS_ASSOCIATI_CHECKREC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CheckRecord') and o.name = 'FK_CHECKREC_ASSOCIATI_GOODS')
alter table CheckRecord
   drop constraint FK_CHECKREC_ASSOCIATI_GOODS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CheckRecord') and o.name = 'FK_CHECKREC_ASSOCIATI_HANDLING')
alter table CheckRecord
   drop constraint FK_CHECKREC_ASSOCIATI_HANDLING
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CheckRecord') and o.name = 'FK_CHECKREC_ASSOCIATI_VEHICLE')
alter table CheckRecord
   drop constraint FK_CHECKREC_ASSOCIATI_VEHICLE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CheckRecord') and o.name = 'FK_CHECKREC_ASSOCIATI_CUSTOMER')
alter table CheckRecord
   drop constraint FK_CHECKREC_ASSOCIATI_CUSTOMER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Goods') and o.name = 'FK_GOODS_ASSOCIATI_UNIT')
alter table Goods
   drop constraint FK_GOODS_ASSOCIATI_UNIT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Goods') and o.name = 'FK_GOODS_ASSOCIATI_CUSTOMER')
alter table Goods
   drop constraint FK_GOODS_ASSOCIATI_CUSTOMER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Goods') and o.name = 'FK_GOODS_ASSOCIATI_HANDLING')
alter table Goods
   drop constraint FK_GOODS_ASSOCIATI_HANDLING
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Goods') and o.name = 'FK_GOODS_ASSOCIATI_STOREMOD')
alter table Goods
   drop constraint FK_GOODS_ASSOCIATI_STOREMOD
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('GoodsAttributeValues') and o.name = 'FK_GOODSATT_ASSOCIATI_GOODS')
alter table GoodsAttributeValues
   drop constraint FK_GOODSATT_ASSOCIATI_GOODS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('InvoicedRecord') and o.name = 'FK_INVOICED_ASSOCIATI_RECEIVED')
alter table InvoicedRecord
   drop constraint FK_INVOICED_ASSOCIATI_RECEIVED
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('InvoicedRecord') and o.name = 'FK_INVOICED_ASSOCIATI_CUSTOMER')
alter table InvoicedRecord
   drop constraint FK_INVOICED_ASSOCIATI_CUSTOMER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('InvoicedRecord') and o.name = 'FK_INVOICED_ASSOCIATI_STOREINO')
alter table InvoicedRecord
   drop constraint FK_INVOICED_ASSOCIATI_STOREINO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ReceivedMoney') and o.name = 'FK_RECEIVED_ASSOCIATI_STOREINO')
alter table ReceivedMoney
   drop constraint FK_RECEIVED_ASSOCIATI_STOREINO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ReceivedMoney') and o.name = 'FK_RECEIVED_ASSOCIATI_CUSTOMER')
alter table ReceivedMoney
   drop constraint FK_RECEIVED_ASSOCIATI_CUSTOMER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ReceivedOfStoreInGoods') and o.name = 'FK_RECEIVED_RECEIVEDO_RECEIVED')
alter table ReceivedOfStoreInGoods
   drop constraint FK_RECEIVED_RECEIVEDO_RECEIVED
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ReceivedOfStoreInGoods') and o.name = 'FK_RECEIVED_RECEIVEDO_STOREING')
alter table ReceivedOfStoreInGoods
   drop constraint FK_RECEIVED_RECEIVEDO_STOREING
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ReceivedUnitPrice') and o.name = 'FK_RECEIVED_ASSOCIATI_RECEIVED')
alter table ReceivedUnitPrice
   drop constraint FK_RECEIVED_ASSOCIATI_RECEIVED
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Store') and o.name = 'FK_STORE_ASSOCIATI_STOREDOM')
alter table Store
   drop constraint FK_STORE_ASSOCIATI_STOREDOM
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('StoreInCost') and o.name = 'FK_STOREINC_ASSOCIATI_STOREINO')
alter table StoreInCost
   drop constraint FK_STOREINC_ASSOCIATI_STOREINO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('StoreInGoods') and o.name = 'FK_STOREING_ASSOCIATI_GOODS')
alter table StoreInGoods
   drop constraint FK_STOREING_ASSOCIATI_GOODS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('StoreInGoods') and o.name = 'FK_STOREING_ASSOCIATI_STOREINO')
alter table StoreInGoods
   drop constraint FK_STOREING_ASSOCIATI_STOREINO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('StoreInGoods') and o.name = 'FK_STOREING_ASSOCIATI_CUSTOMER')
alter table StoreInGoods
   drop constraint FK_STOREING_ASSOCIATI_CUSTOMER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('StoreInGoods') and o.name = 'FK_STOREING_ASSOCIATI_STORE')
alter table StoreInGoods
   drop constraint FK_STOREING_ASSOCIATI_STORE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('StoreInGoods') and o.name = 'FK_STOREING_ASSOCIATI_STOREMOD')
alter table StoreInGoods
   drop constraint FK_STOREING_ASSOCIATI_STOREMOD
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('StoreInGoodsVehicle') and o.name = 'FK_STOREING_ASSOCIATI_VEHICLE')
alter table StoreInGoodsVehicle
   drop constraint FK_STOREING_ASSOCIATI_VEHICLE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('StoreInGoodsWithVehicles') and o.name = 'FK_STOREING_STOREINGO_STOREING')
alter table StoreInGoodsWithVehicles
   drop constraint FK_STOREING_STOREINGO_STOREING
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('StoreInGoodsWithVehicles') and o.name = 'FK_STOREING_STOREINGO_STOREING')
alter table StoreInGoodsWithVehicles
   drop constraint FK_STOREING_STOREINGO_STOREING
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('StoreInOrder') and o.name = 'FK_STOREINO_ASSOCIATI_CUSTOMER')
alter table StoreInOrder
   drop constraint FK_STOREINO_ASSOCIATI_CUSTOMER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('StoreInUnitPrice') and o.name = 'FK_STOREINU_ASSOCIATI_STOREINO')
alter table StoreInUnitPrice
   drop constraint FK_STOREINU_ASSOCIATI_STOREINO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('StoreOutCost') and o.name = 'FK_STOREOUT_ASSOCIATI_STOREOUT')
alter table StoreOutCost
   drop constraint FK_STOREOUT_ASSOCIATI_STOREOUT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('StoreOutGoods') and o.name = 'FK_STOREOUT_ASSOCIATI_GOODS')
alter table StoreOutGoods
   drop constraint FK_STOREOUT_ASSOCIATI_GOODS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('StoreOutGoods') and o.name = 'FK_STOREOUT_ASSOCIATI_STOREING')
alter table StoreOutGoods
   drop constraint FK_STOREOUT_ASSOCIATI_STOREING
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('StoreOutGoods') and o.name = 'FK_STOREOUT_ASSOCIATI_STOREOUT')
alter table StoreOutGoods
   drop constraint FK_STOREOUT_ASSOCIATI_STOREOUT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('StoreOutGoods') and o.name = 'FK_STOREOUT_ASSOCIATI_STOREINO')
alter table StoreOutGoods
   drop constraint FK_STOREOUT_ASSOCIATI_STOREINO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('StoreOutGoodsVehicle') and o.name = 'FK_STOREOUT_ASSOCIATI_VEHICLE')
alter table StoreOutGoodsVehicle
   drop constraint FK_STOREOUT_ASSOCIATI_VEHICLE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('StoreOutGoodsWithVehicles') and o.name = 'FK_STOREOUT_STOREOUTG_STOREOUT')
alter table StoreOutGoodsWithVehicles
   drop constraint FK_STOREOUT_STOREOUTG_STOREOUT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('StoreOutGoodsWithVehicles') and o.name = 'FK_STOREOUT_STOREOUTG_STOREOUT')
alter table StoreOutGoodsWithVehicles
   drop constraint FK_STOREOUT_STOREOUTG_STOREOUT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('StoreOutOrder') and o.name = 'FK_STOREOUT_ASSOCIATI_STOREINU')
alter table StoreOutOrder
   drop constraint FK_STOREOUT_ASSOCIATI_STOREINU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('StoreOutOrder') and o.name = 'FK_STOREOUT_ASSOCIATI_CUSTOMER')
alter table StoreOutOrder
   drop constraint FK_STOREOUT_ASSOCIATI_CUSTOMER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('StoreOutUnitPrice') and o.name = 'FK_STOREOUT_ASSOCIATI_STOREOUT')
alter table StoreOutUnitPrice
   drop constraint FK_STOREOUT_ASSOCIATI_STOREOUT
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('AllotGoods')
            and   name  = 'Association38_FK'
            and   indid > 0
            and   indid < 255)
   drop index AllotGoods.Association38_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('AllotGoods')
            and   name  = 'Association24_FK'
            and   indid > 0
            and   indid < 255)
   drop index AllotGoods.Association24_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('AllotGoods')
            and   name  = 'Association23_FK'
            and   indid > 0
            and   indid < 255)
   drop index AllotGoods.Association23_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('AllotGoods')
            and   type = 'U')
   drop table AllotGoods
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('AllotOrder')
            and   name  = 'Association21_FK'
            and   indid > 0
            and   indid < 255)
   drop index AllotOrder.Association21_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('AllotOrder')
            and   name  = 'Association20_FK'
            and   indid > 0
            and   indid < 255)
   drop index AllotOrder.Association20_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('AllotOrder')
            and   type = 'U')
   drop table AllotOrder
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Attach')
            and   type = 'U')
   drop table Attach
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CheckCost')
            and   type = 'U')
   drop table CheckCost
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CheckRecord')
            and   name  = 'Association36_FK'
            and   indid > 0
            and   indid < 255)
   drop index CheckRecord.Association36_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CheckRecord')
            and   name  = 'Association35_FK'
            and   indid > 0
            and   indid < 255)
   drop index CheckRecord.Association35_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CheckRecord')
            and   name  = 'Association34_FK'
            and   indid > 0
            and   indid < 255)
   drop index CheckRecord.Association34_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CheckRecord')
            and   name  = 'Association33_FK'
            and   indid > 0
            and   indid < 255)
   drop index CheckRecord.Association33_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CheckRecord')
            and   type = 'U')
   drop table CheckRecord
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Customer')
            and   type = 'U')
   drop table Customer
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Goods')
            and   name  = 'Association7_FK'
            and   indid > 0
            and   indid < 255)
   drop index Goods.Association7_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Goods')
            and   name  = 'Association6_FK'
            and   indid > 0
            and   indid < 255)
   drop index Goods.Association6_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Goods')
            and   name  = 'Association5_FK'
            and   indid > 0
            and   indid < 255)
   drop index Goods.Association5_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Goods')
            and   name  = 'Association1_FK'
            and   indid > 0
            and   indid < 255)
   drop index Goods.Association1_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Goods')
            and   type = 'U')
   drop table Goods
go

if exists (select 1
            from  sysobjects
           where  id = object_id('GoodsAttributeValues')
            and   type = 'U')
   drop table GoodsAttributeValues
go

if exists (select 1
            from  sysobjects
           where  id = object_id('HandlingMode')
            and   type = 'U')
   drop table HandlingMode
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('InvoicedRecord')
            and   name  = 'Association46_FK'
            and   indid > 0
            and   indid < 255)
   drop index InvoicedRecord.Association46_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('InvoicedRecord')
            and   name  = 'Association45_FK'
            and   indid > 0
            and   indid < 255)
   drop index InvoicedRecord.Association45_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('InvoicedRecord')
            and   name  = 'Association44_FK'
            and   indid > 0
            and   indid < 255)
   drop index InvoicedRecord.Association44_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('InvoicedRecord')
            and   type = 'U')
   drop table InvoicedRecord
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ReceivedMoney')
            and   name  = 'Association43_FK'
            and   indid > 0
            and   indid < 255)
   drop index ReceivedMoney.Association43_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ReceivedMoney')
            and   name  = 'Association41_FK'
            and   indid > 0
            and   indid < 255)
   drop index ReceivedMoney.Association41_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ReceivedMoney')
            and   type = 'U')
   drop table ReceivedMoney
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ReceivedOfStoreInGoods')
            and   name  = 'Association51_FK2'
            and   indid > 0
            and   indid < 255)
   drop index ReceivedOfStoreInGoods.Association51_FK2
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ReceivedOfStoreInGoods')
            and   name  = 'Association51_FK'
            and   indid > 0
            and   indid < 255)
   drop index ReceivedOfStoreInGoods.Association51_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ReceivedOfStoreInGoods')
            and   type = 'U')
   drop table ReceivedOfStoreInGoods
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ReceivedUnitPrice')
            and   type = 'U')
   drop table ReceivedUnitPrice
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Store')
            and   name  = 'Association4_FK'
            and   indid > 0
            and   indid < 255)
   drop index Store.Association4_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Store')
            and   type = 'U')
   drop table Store
go

if exists (select 1
            from  sysobjects
           where  id = object_id('StoreDomain')
            and   type = 'U')
   drop table StoreDomain
go

if exists (select 1
            from  sysobjects
           where  id = object_id('StoreInCost')
            and   type = 'U')
   drop table StoreInCost
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('StoreInGoods')
            and   name  = 'Association22_FK'
            and   indid > 0
            and   indid < 255)
   drop index StoreInGoods.Association22_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('StoreInGoods')
            and   name  = 'Association19_FK'
            and   indid > 0
            and   indid < 255)
   drop index StoreInGoods.Association19_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('StoreInGoods')
            and   name  = 'Association18_FK'
            and   indid > 0
            and   indid < 255)
   drop index StoreInGoods.Association18_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('StoreInGoods')
            and   name  = 'Association16_FK'
            and   indid > 0
            and   indid < 255)
   drop index StoreInGoods.Association16_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('StoreInGoods')
            and   name  = 'Association15_FK'
            and   indid > 0
            and   indid < 255)
   drop index StoreInGoods.Association15_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('StoreInGoods')
            and   type = 'U')
   drop table StoreInGoods
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('StoreInGoodsVehicle')
            and   name  = 'Association53_FK'
            and   indid > 0
            and   indid < 255)
   drop index StoreInGoodsVehicle.Association53_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('StoreInGoodsVehicle')
            and   type = 'U')
   drop table StoreInGoodsVehicle
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('StoreInGoodsWithVehicles')
            and   name  = 'Association54_FK'
            and   indid > 0
            and   indid < 255)
   drop index StoreInGoodsWithVehicles.Association54_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('StoreInGoodsWithVehicles')
            and   type = 'U')
   drop table StoreInGoodsWithVehicles
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('StoreInOrder')
            and   name  = 'Association10_FK'
            and   indid > 0
            and   indid < 255)
   drop index StoreInOrder.Association10_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('StoreInOrder')
            and   type = 'U')
   drop table StoreInOrder
go

if exists (select 1
            from  sysobjects
           where  id = object_id('StoreInUnitPrice')
            and   type = 'U')
   drop table StoreInUnitPrice
go

if exists (select 1
            from  sysobjects
           where  id = object_id('StoreMode')
            and   type = 'U')
   drop table StoreMode
go

if exists (select 1
            from  sysobjects
           where  id = object_id('StoreOutCost')
            and   type = 'U')
   drop table StoreOutCost
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('StoreOutGoods')
            and   name  = 'Association48_FK'
            and   indid > 0
            and   indid < 255)
   drop index StoreOutGoods.Association48_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('StoreOutGoods')
            and   name  = 'Association32_FK'
            and   indid > 0
            and   indid < 255)
   drop index StoreOutGoods.Association32_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('StoreOutGoods')
            and   name  = 'Association31_FK'
            and   indid > 0
            and   indid < 255)
   drop index StoreOutGoods.Association31_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('StoreOutGoods')
            and   name  = 'Association30_FK'
            and   indid > 0
            and   indid < 255)
   drop index StoreOutGoods.Association30_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('StoreOutGoods')
            and   type = 'U')
   drop table StoreOutGoods
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('StoreOutGoodsVehicle')
            and   name  = 'Association49_FK'
            and   indid > 0
            and   indid < 255)
   drop index StoreOutGoodsVehicle.Association49_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('StoreOutGoodsVehicle')
            and   type = 'U')
   drop table StoreOutGoodsVehicle
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('StoreOutGoodsWithVehicles')
            and   name  = 'StoreOutGoodsWithVehicles_FK'
            and   indid > 0
            and   indid < 255)
   drop index StoreOutGoodsWithVehicles.StoreOutGoodsWithVehicles_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('StoreOutGoodsWithVehicles')
            and   type = 'U')
   drop table StoreOutGoodsWithVehicles
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('StoreOutOrder')
            and   name  = 'Association29_FK'
            and   indid > 0
            and   indid < 255)
   drop index StoreOutOrder.Association29_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('StoreOutOrder')
            and   name  = 'Association27_FK'
            and   indid > 0
            and   indid < 255)
   drop index StoreOutOrder.Association27_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('StoreOutOrder')
            and   type = 'U')
   drop table StoreOutOrder
go

if exists (select 1
            from  sysobjects
           where  id = object_id('StoreOutUnitPrice')
            and   type = 'U')
   drop table StoreOutUnitPrice
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Unit')
            and   type = 'U')
   drop table Unit
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Vehicle')
            and   type = 'U')
   drop table Vehicle
go

/*==============================================================*/
/* Table: AllotGoods                                            */
/*==============================================================*/
create table AllotGoods (
   AllotOrderId         int                  not null,
   Id                   int                  not null,
   StoreInOrderId       int                  not null,
   GoodsId              int                  not null,
   StoreInGoodsStoreInOrderId int                  not null,
   StoreInGoodsId       int                  not null,
   Remark               varchar(254)         null,
   Count                decimal              null,
   Status               int                  null,
   constraint PK_ALLOTGOODS primary key (AllotOrderId, Id)
)
go

/*==============================================================*/
/* Index: Association23_FK                                      */
/*==============================================================*/
create index Association23_FK on AllotGoods (
GoodsId ASC
)
go

/*==============================================================*/
/* Index: Association24_FK                                      */
/*==============================================================*/
create index Association24_FK on AllotGoods (
StoreInGoodsStoreInOrderId ASC,
StoreInGoodsId ASC
)
go

/*==============================================================*/
/* Index: Association38_FK                                      */
/*==============================================================*/
create index Association38_FK on AllotGoods (
StoreInOrderId ASC
)
go

/*==============================================================*/
/* Table: AllotOrder                                            */
/*==============================================================*/
create table AllotOrder (
   Id                   int                  not null,
   PurposeStoreId       int                  not null,
   SourceStoreId        int                  not null,
   Remark               varchar(254)         null,
   CreateTime           datetime             null,
   Admin                varchar(254)         null,
   constraint PK_ALLOTORDER primary key nonclustered (Id)
)
go

/*==============================================================*/
/* Index: Association20_FK                                      */
/*==============================================================*/
create index Association20_FK on AllotOrder (
PurposeStoreId ASC
)
go

/*==============================================================*/
/* Index: Association21_FK                                      */
/*==============================================================*/
create index Association21_FK on AllotOrder (
SourceStoreId ASC
)
go

/*==============================================================*/
/* Table: Attach                                                */
/*==============================================================*/
create table Attach (
   StoreInGoodsStoreInOrderId int                  not null,
   StoreInGoodsId       int                  not null,
   FilePath             varchar(254)         null,
   CreateTime           datetime             null,
   Admin                varchar(254)         null,
   Remark               varchar(254)         null,
   constraint PK_ATTACH primary key (StoreInGoodsStoreInOrderId, StoreInGoodsId)
)
go

/*==============================================================*/
/* Table: CheckCost                                             */
/*==============================================================*/
create table CheckCost (
   CheckRecordId        int                  not null,
   Name                 varchar(254)         null,
   Count                decimal              null,
   UnitPrice            decimal              null,
   TotalPrice           decimal              null,
   Status               int                  null,
   PaidTime             datetime             null,
   Admin                varchar(254)         null,
   Customer             varchar(254)         null,
   HasBeenInvoiced      bit                  null,
   InvoicedTime         datetime             null,
   InvoicedOperator     varchar(254)         null,
   Remark               varchar(254)         null,
   constraint PK_CHECKCOST primary key (CheckRecordId)
)
go

/*==============================================================*/
/* Table: CheckRecord                                           */
/*==============================================================*/
create table CheckRecord (
   Id                   int                  not null,
   VehicleId            int                  not null,
   CustomerId           int                  not null,
   HandlingModeId       int                  not null,
   GoodsId              int                  not null,
   Status               int                  null,
   CreateTime           datetime             null,
   Admin                varchar(254)         null,
   InspectionNumber     varchar(254)         null,
   CaseNumber           varchar(254)         null,
   CheckResult          varchar(254)         null,
   RealName             varchar(254)         null,
   LinkMan              varchar(254)         null,
   Remark               varchar(254)         null,
   constraint PK_CHECKRECORD primary key nonclustered (Id)
)
go

/*==============================================================*/
/* Index: Association33_FK                                      */
/*==============================================================*/
create index Association33_FK on CheckRecord (
GoodsId ASC
)
go

/*==============================================================*/
/* Index: Association34_FK                                      */
/*==============================================================*/
create index Association34_FK on CheckRecord (
HandlingModeId ASC
)
go

/*==============================================================*/
/* Index: Association35_FK                                      */
/*==============================================================*/
create index Association35_FK on CheckRecord (
VehicleId ASC
)
go

/*==============================================================*/
/* Index: Association36_FK                                      */
/*==============================================================*/
create index Association36_FK on CheckRecord (
CustomerId ASC
)
go

/*==============================================================*/
/* Table: Customer                                              */
/*==============================================================*/
create table Customer (
   Id                   int                  not null,
   Code                 varchar(254)         null,
   Name                 varchar(254)         null,
   LinkMan              varchar(254)         null,
   LinkTel              varchar(254)         null,
   LinkAddress          varchar(254)         null,
   Email                varchar(254)         null,
   Fax                  varchar(254)         null,
   Status               int                  null,
   Remark               varchar(254)         null,
   constraint PK_CUSTOMER primary key nonclustered (Id)
)
go

/*==============================================================*/
/* Table: Goods                                                 */
/*==============================================================*/
create table Goods (
   Id                   int                  not null,
   UnitId               int                  not null,
   CustomerId           int                  not null,
   StoreModeId          int                  not null,
   HandlingModeId       int                  not null,
   Name                 varchar(254)         null,
   constraint PK_GOODS primary key nonclustered (Id)
)
go

/*==============================================================*/
/* Index: Association1_FK                                       */
/*==============================================================*/
create index Association1_FK on Goods (
UnitId ASC
)
go

/*==============================================================*/
/* Index: Association5_FK                                       */
/*==============================================================*/
create index Association5_FK on Goods (
CustomerId ASC
)
go

/*==============================================================*/
/* Index: Association6_FK                                       */
/*==============================================================*/
create index Association6_FK on Goods (
HandlingModeId ASC
)
go

/*==============================================================*/
/* Index: Association7_FK                                       */
/*==============================================================*/
create index Association7_FK on Goods (
StoreModeId ASC
)
go

/*==============================================================*/
/* Table: GoodsAttributeValues                                  */
/*==============================================================*/
create table GoodsAttributeValues (
   GoodsId              int                  not null,
   AttributeName        varchar(254)         null,
   AttributeValue       varchar(254)         null,
   Remark               varchar(254)         null,
   constraint PK_GOODSATTRIBUTEVALUES primary key (GoodsId)
)
go

/*==============================================================*/
/* Table: HandlingMode                                          */
/*==============================================================*/
create table HandlingMode (
   Id                   int                  not null,
   Name                 varchar(254)         null,
   Remark               varchar(254)         null,
   constraint PK_HANDLINGMODE primary key nonclustered (Id)
)
go

/*==============================================================*/
/* Table: InvoicedRecord                                        */
/*==============================================================*/
create table InvoicedRecord (
   Id                   int                  not null,
   ReceivedMoneyId      int                  not null,
   StoreInOrderId       int                  not null,
   CustomerId           int                  not null,
   Remark               varchar(254)         null,
   CreateTime           datetime             null,
   Admin                varchar(254)         null,
   Price                decimal              null,
   constraint PK_INVOICEDRECORD primary key nonclustered (Id)
)
go

/*==============================================================*/
/* Index: Association44_FK                                      */
/*==============================================================*/
create index Association44_FK on InvoicedRecord (
ReceivedMoneyId ASC
)
go

/*==============================================================*/
/* Index: Association45_FK                                      */
/*==============================================================*/
create index Association45_FK on InvoicedRecord (
CustomerId ASC
)
go

/*==============================================================*/
/* Index: Association46_FK                                      */
/*==============================================================*/
create index Association46_FK on InvoicedRecord (
StoreInOrderId ASC
)
go

/*==============================================================*/
/* Table: ReceivedMoney                                         */
/*==============================================================*/
create table ReceivedMoney (
   Id                   int                  not null,
   StoreInOrderId       int                  not null,
   CustomerId           int                  not null,
   Name                 varchar(254)         null,
   BeginChargingTime    datetime             null,
   EndChargingTime2     datetime             null,
   ChargingCount        decimal              null,
   TotalPrice           decimal              null,
   FactTotalPrice       decimal              null,
   CreateTime           datetime             null,
   Admin                varchar(254)         null,
   Remark               varchar(254)         null,
   Status               int                  null,
   constraint PK_RECEIVEDMONEY primary key nonclustered (Id)
)
go

/*==============================================================*/
/* Index: Association41_FK                                      */
/*==============================================================*/
create index Association41_FK on ReceivedMoney (
StoreInOrderId ASC
)
go

/*==============================================================*/
/* Index: Association43_FK                                      */
/*==============================================================*/
create index Association43_FK on ReceivedMoney (
CustomerId ASC
)
go

/*==============================================================*/
/* Table: ReceivedOfStoreInGoods                                */
/*==============================================================*/
create table ReceivedOfStoreInGoods (
   ReceivedMoneyId      int                  not null,
   StoreInGoodsStoreInOrderId int                  not null,
   StoreInGoodsId       int                  not null,
   constraint PK_RECEIVEDOFSTOREINGOODS primary key (StoreInGoodsStoreInOrderId, ReceivedMoneyId, StoreInGoodsId)
)
go

/*==============================================================*/
/* Index: Association51_FK                                      */
/*==============================================================*/
create index Association51_FK on ReceivedOfStoreInGoods (
ReceivedMoneyId ASC
)
go

/*==============================================================*/
/* Index: Association51_FK2                                     */
/*==============================================================*/
create index Association51_FK2 on ReceivedOfStoreInGoods (
StoreInGoodsStoreInOrderId ASC,
StoreInGoodsId ASC
)
go

/*==============================================================*/
/* Table: ReceivedUnitPrice                                     */
/*==============================================================*/
create table ReceivedUnitPrice (
   ReceivedMoneyId      int                  not null,
   BeginTime            datetime             null,
   Price                decimal              null,
   EndTime              datetime             null,
   Remark               varchar(254)         null,
   constraint PK_RECEIVEDUNITPRICE primary key (ReceivedMoneyId)
)
go

/*==============================================================*/
/* Table: Store                                                 */
/*==============================================================*/
create table Store (
   Id                   int                  not null,
   StoreDomainId        int                  not null,
   Name                 varchar(254)         null,
   Manager              varchar(254)         null,
   Address              varchar(254)         null,
   Remark               varchar(254)         null,
   constraint PK_STORE primary key nonclustered (Id)
)
go

/*==============================================================*/
/* Index: Association4_FK                                       */
/*==============================================================*/
create index Association4_FK on Store (
StoreDomainId ASC
)
go

/*==============================================================*/
/* Table: StoreDomain                                           */
/*==============================================================*/
create table StoreDomain (
   Id                   int                  not null,
   Name                 varchar(254)         null,
   Remark               varchar(254)         null,
   constraint PK_STOREDOMAIN primary key nonclustered (Id)
)
go

/*==============================================================*/
/* Table: StoreInCost                                           */
/*==============================================================*/
create table StoreInCost (
   StoreInOrderId       int                  not null,
   Name                 varchar(254)         null,
   Count                decimal              null,
   UnitPrice            decimal              null,
   TotalPrice           decimal              null,
   Status               int                  null,
   PaidTime             datetime             null,
   Admin                varchar(254)         null,
   Customer             varchar(254)         null,
   HasBeenInvoiced      bit                  null,
   InvoicedTime         datetime             null,
   InvoicedOperator     varchar(254)         null,
   Remark               varchar(254)         null,
   constraint PK_STOREINCOST primary key (StoreInOrderId)
)
go

/*==============================================================*/
/* Table: StoreInGoods                                          */
/*==============================================================*/
create table StoreInGoods (
   StoreInOrderId       int                  not null,
   Id                   int                  not null,
   StoreId              int                  not null,
   StoreModeId          int                  not null,
   CustomerId           int                  not null,
   GoodsId              int                  not null,
   Status               int                  null,
   Count                decimal              null,
   StoredInTime         datetime             null,
   Remark               varchar(254)         null,
   constraint PK_STOREINGOODS primary key nonclustered (StoreInOrderId, Id)
)
go

/*==============================================================*/
/* Index: Association15_FK                                      */
/*==============================================================*/
create index Association15_FK on StoreInGoods (
GoodsId ASC
)
go

/*==============================================================*/
/* Index: Association16_FK                                      */
/*==============================================================*/
create index Association16_FK on StoreInGoods (
StoreInOrderId ASC
)
go

/*==============================================================*/
/* Index: Association18_FK                                      */
/*==============================================================*/
create index Association18_FK on StoreInGoods (
CustomerId ASC
)
go

/*==============================================================*/
/* Index: Association19_FK                                      */
/*==============================================================*/
create index Association19_FK on StoreInGoods (
StoreId ASC
)
go

/*==============================================================*/
/* Index: Association22_FK                                      */
/*==============================================================*/
create index Association22_FK on StoreInGoods (
StoreModeId ASC
)
go

/*==============================================================*/
/* Table: StoreInGoodsVehicle                                   */
/*==============================================================*/
create table StoreInGoodsVehicle (
   Id                   int                  not null,
   VehicleId            int                  not null,
   Remark               varchar(254)         null,
   Count                decimal              null,
   constraint PK_STOREINGOODSVEHICLE primary key nonclustered (Id)
)
go

/*==============================================================*/
/* Index: Association53_FK                                      */
/*==============================================================*/
create index Association53_FK on StoreInGoodsVehicle (
VehicleId ASC
)
go

/*==============================================================*/
/* Table: StoreInGoodsWithVehicles                              */
/*==============================================================*/
create table StoreInGoodsWithVehicles (
   StoreInGoodsStoreInOrderId int                  not null,
   StoreInGoodsId       int                  not null,
   StoreInGoodsVehicleId int                  not null,
   constraint PK_STOREINGOODSWITHVEHICLES primary key (StoreInGoodsStoreInOrderId, StoreInGoodsId, StoreInGoodsVehicleId)
)
go

/*==============================================================*/
/* Index: Association54_FK                                      */
/*==============================================================*/
create index Association54_FK on StoreInGoodsWithVehicles (
StoreInGoodsVehicleId ASC
)
go

/*==============================================================*/
/* Table: StoreInOrder                                          */
/*==============================================================*/
create table StoreInOrder (
   Id                   int                  not null,
   CustomerId           int                  not null,
   Status               int                  null,
   CreateTime           datetime             null,
   BeginChargingTime    datetime             null,
   ChargingTime         datetime             null,
   Admin                varchar(254)         null,
   ChargingCount        decimal              null,
   InspectionNumber     varchar(254)         null,
   AccountNumber        varchar(254)         null,
   SuttleWeight         decimal              null,
   FreeDays             int                  null,
   Remark               varchar(254)         null,
   constraint PK_STOREINORDER primary key nonclustered (Id)
)
go

/*==============================================================*/
/* Index: Association10_FK                                      */
/*==============================================================*/
create index Association10_FK on StoreInOrder (
CustomerId ASC
)
go

/*==============================================================*/
/* Table: StoreInUnitPrice                                      */
/*==============================================================*/
create table StoreInUnitPrice (
   StoreInOrderId       int                  not null,
   BeginTime            datetime             null,
   Price                decimal              null,
   EndTime              datetime             null,
   Remark               varchar(254)         null,
   constraint PK_STOREINUNITPRICE primary key (StoreInOrderId)
)
go

/*==============================================================*/
/* Table: StoreMode                                             */
/*==============================================================*/
create table StoreMode (
   Id                   int                  not null,
   Name                 varchar(254)         null,
   Remark               varchar(254)         null,
   constraint PK_STOREMODE primary key nonclustered (Id)
)
go

/*==============================================================*/
/* Table: StoreOutCost                                          */
/*==============================================================*/
create table StoreOutCost (
   StoreOutOrderId      int                  not null,
   Name                 varchar(254)         null,
   Count                decimal              null,
   UnitPrice            decimal              null,
   TotalPrice           decimal              null,
   Status               int                  null,
   PaidTime             datetime             null,
   Admin                varchar(254)         null,
   Customer             varchar(254)         null,
   HasBeenInvoiced      bit                  null,
   InvoicedTime         datetime             null,
   InvoicedOperator     varchar(254)         null,
   Remark               varchar(254)         null,
   constraint PK_STOREOUTCOST primary key (StoreOutOrderId)
)
go

/*==============================================================*/
/* Table: StoreOutGoods                                         */
/*==============================================================*/
create table StoreOutGoods (
   StoreOutOrderId      int                  not null,
   Id                   int                  not null,
   GoodsId              int                  not null,
   StoreInOrderId       int                  not null,
   StoreInGoodsStoreInOrderId int                  not null,
   StoreInGoodsId       int                  not null,
   Remark               varchar(254)         null,
   StoringOutTime       datetime             null,
   FactStoringOutTime   datetime             null,
   Status               int                  null,
   Count                decimal              null,
   constraint PK_STOREOUTGOODS primary key nonclustered (StoreOutOrderId, Id)
)
go

/*==============================================================*/
/* Index: Association30_FK                                      */
/*==============================================================*/
create index Association30_FK on StoreOutGoods (
GoodsId ASC
)
go

/*==============================================================*/
/* Index: Association31_FK                                      */
/*==============================================================*/
create index Association31_FK on StoreOutGoods (
StoreInGoodsStoreInOrderId ASC,
StoreInGoodsId ASC
)
go

/*==============================================================*/
/* Index: Association32_FK                                      */
/*==============================================================*/
create index Association32_FK on StoreOutGoods (
StoreOutOrderId ASC
)
go

/*==============================================================*/
/* Index: Association48_FK                                      */
/*==============================================================*/
create index Association48_FK on StoreOutGoods (
StoreInOrderId ASC
)
go

/*==============================================================*/
/* Table: StoreOutGoodsVehicle                                  */
/*==============================================================*/
create table StoreOutGoodsVehicle (
   Id                   int                  not null,
   VehicleId            int                  not null,
   Remark               varchar(254)         null,
   Count                decimal              null,
   constraint PK_STOREOUTGOODSVEHICLE primary key nonclustered (Id)
)
go

/*==============================================================*/
/* Index: Association49_FK                                      */
/*==============================================================*/
create index Association49_FK on StoreOutGoodsVehicle (
VehicleId ASC
)
go

/*==============================================================*/
/* Table: StoreOutGoodsWithVehicles                             */
/*==============================================================*/
create table StoreOutGoodsWithVehicles (
   StoreOutGoodsStoreOutOrderId int                  not null,
   StoreOutGoodsId      int                  not null,
   StoreOutGoodsVehicleId int                  not null,
   constraint PK_STOREOUTGOODSWITHVEHICLES primary key (StoreOutGoodsStoreOutOrderId, StoreOutGoodsId, StoreOutGoodsVehicleId)
)
go

/*==============================================================*/
/* Index: StoreOutGoodsWithVehicles_FK                          */
/*==============================================================*/
create index StoreOutGoodsWithVehicles_FK on StoreOutGoodsWithVehicles (
StoreOutGoodsVehicleId ASC
)
go

/*==============================================================*/
/* Table: StoreOutOrder                                         */
/*==============================================================*/
create table StoreOutOrder (
   Id                   int                  not null,
   CustomerId           int                  not null,
   StoreInUnitPriceStoreInOrderId int                  not null,
   CreateTime           datetime             null,
   Admin                varchar(254)         null,
   InvoiceMoney         decimal              null,
   HasBeenInvoiced      bit                  null,
   Status               int                  null,
   Remark               varchar(254)         null,
   constraint PK_STOREOUTORDER primary key nonclustered (Id)
)
go

/*==============================================================*/
/* Index: Association27_FK                                      */
/*==============================================================*/
create index Association27_FK on StoreOutOrder (
StoreInUnitPriceStoreInOrderId ASC
)
go

/*==============================================================*/
/* Index: Association29_FK                                      */
/*==============================================================*/
create index Association29_FK on StoreOutOrder (
CustomerId ASC
)
go

/*==============================================================*/
/* Table: StoreOutUnitPrice                                     */
/*==============================================================*/
create table StoreOutUnitPrice (
   StoreOutOrderId      int                  not null,
   BeginTime            datetime             null,
   Price                decimal              null,
   EndTime              datetime             null,
   Remark               varchar(254)         null,
   constraint PK_STOREOUTUNITPRICE primary key (StoreOutOrderId)
)
go

/*==============================================================*/
/* Table: Unit                                                  */
/*==============================================================*/
create table Unit (
   Id                   int                  not null,
   Name                 varchar(254)         null,
   Remark               varchar(254)         null,
   constraint PK_UNIT primary key nonclustered (Id)
)
go

/*==============================================================*/
/* Table: Vehicle                                               */
/*==============================================================*/
create table Vehicle (
   Id                   int                  not null,
   PlateNumber          varchar(254)         null,
   Driver               varchar(254)         null,
   LinkTel              varchar(254)         null,
   LinkAddress          varchar(254)         null,
   Remark               varchar(254)         null,
   constraint PK_VEHICLE primary key nonclustered (Id)
)
go

alter table AllotGoods
   add constraint FK_ALLOTGOO_ASSOCIATI_GOODS foreign key (GoodsId)
      references Goods (Id)
go

alter table AllotGoods
   add constraint FK_ALLOTGOO_ASSOCIATI_STOREING foreign key (StoreInGoodsStoreInOrderId, StoreInGoodsId)
      references StoreInGoods (StoreInOrderId, Id)
go

alter table AllotGoods
   add constraint FK_ALLOTGOO_ASSOCIATI_ALLOTORD foreign key (AllotOrderId)
      references AllotOrder (Id)
go

alter table AllotGoods
   add constraint FK_ALLOTGOO_ASSOCIATI_STOREINO foreign key (StoreInOrderId)
      references StoreInOrder (Id)
go

alter table AllotOrder
   add constraint FK_ALLOTORD_ASSOCIATI_STORE foreign key (PurposeStoreId)
      references Store (Id)
go

alter table AllotOrder
   add constraint FK_ALLOTORD_ASSOCIATI_STORE foreign key (SourceStoreId)
      references Store (Id)
go

alter table Attach
   add constraint FK_ATTACH_ASSOCIATI_STOREING foreign key (StoreInGoodsStoreInOrderId, StoreInGoodsId)
      references StoreInGoods (StoreInOrderId, Id)
go

alter table CheckCost
   add constraint FK_CHECKCOS_ASSOCIATI_CHECKREC foreign key (CheckRecordId)
      references CheckRecord (Id)
go

alter table CheckRecord
   add constraint FK_CHECKREC_ASSOCIATI_GOODS foreign key (GoodsId)
      references Goods (Id)
go

alter table CheckRecord
   add constraint FK_CHECKREC_ASSOCIATI_HANDLING foreign key (HandlingModeId)
      references HandlingMode (Id)
go

alter table CheckRecord
   add constraint FK_CHECKREC_ASSOCIATI_VEHICLE foreign key (VehicleId)
      references Vehicle (Id)
go

alter table CheckRecord
   add constraint FK_CHECKREC_ASSOCIATI_CUSTOMER foreign key (CustomerId)
      references Customer (Id)
go

alter table Goods
   add constraint FK_GOODS_ASSOCIATI_UNIT foreign key (UnitId)
      references Unit (Id)
go

alter table Goods
   add constraint FK_GOODS_ASSOCIATI_CUSTOMER foreign key (CustomerId)
      references Customer (Id)
go

alter table Goods
   add constraint FK_GOODS_ASSOCIATI_HANDLING foreign key (HandlingModeId)
      references HandlingMode (Id)
go

alter table Goods
   add constraint FK_GOODS_ASSOCIATI_STOREMOD foreign key (StoreModeId)
      references StoreMode (Id)
go

alter table GoodsAttributeValues
   add constraint FK_GOODSATT_ASSOCIATI_GOODS foreign key (GoodsId)
      references Goods (Id)
go

alter table InvoicedRecord
   add constraint FK_INVOICED_ASSOCIATI_RECEIVED foreign key (ReceivedMoneyId)
      references ReceivedMoney (Id)
go

alter table InvoicedRecord
   add constraint FK_INVOICED_ASSOCIATI_CUSTOMER foreign key (CustomerId)
      references Customer (Id)
go

alter table InvoicedRecord
   add constraint FK_INVOICED_ASSOCIATI_STOREINO foreign key (StoreInOrderId)
      references StoreInOrder (Id)
go

alter table ReceivedMoney
   add constraint FK_RECEIVED_ASSOCIATI_STOREINO foreign key (StoreInOrderId)
      references StoreInOrder (Id)
go

alter table ReceivedMoney
   add constraint FK_RECEIVED_ASSOCIATI_CUSTOMER foreign key (CustomerId)
      references Customer (Id)
go

alter table ReceivedOfStoreInGoods
   add constraint FK_RECEIVED_RECEIVEDO_RECEIVED foreign key (ReceivedMoneyId)
      references ReceivedMoney (Id)
go

alter table ReceivedOfStoreInGoods
   add constraint FK_RECEIVED_RECEIVEDO_STOREING foreign key (StoreInGoodsStoreInOrderId, StoreInGoodsId)
      references StoreInGoods (StoreInOrderId, Id)
go

alter table ReceivedUnitPrice
   add constraint FK_RECEIVED_ASSOCIATI_RECEIVED foreign key (ReceivedMoneyId)
      references ReceivedMoney (Id)
go

alter table Store
   add constraint FK_STORE_ASSOCIATI_STOREDOM foreign key (StoreDomainId)
      references StoreDomain (Id)
go

alter table StoreInCost
   add constraint FK_STOREINC_ASSOCIATI_STOREINO foreign key (StoreInOrderId)
      references StoreInOrder (Id)
go

alter table StoreInGoods
   add constraint FK_STOREING_ASSOCIATI_GOODS foreign key (GoodsId)
      references Goods (Id)
go

alter table StoreInGoods
   add constraint FK_STOREING_ASSOCIATI_STOREINO foreign key (StoreInOrderId)
      references StoreInOrder (Id)
go

alter table StoreInGoods
   add constraint FK_STOREING_ASSOCIATI_CUSTOMER foreign key (CustomerId)
      references Customer (Id)
go

alter table StoreInGoods
   add constraint FK_STOREING_ASSOCIATI_STORE foreign key (StoreId)
      references Store (Id)
go

alter table StoreInGoods
   add constraint FK_STOREING_ASSOCIATI_STOREMOD foreign key (StoreModeId)
      references StoreMode (Id)
go

alter table StoreInGoodsVehicle
   add constraint FK_STOREING_ASSOCIATI_VEHICLE foreign key (VehicleId)
      references Vehicle (Id)
go

alter table StoreInGoodsWithVehicles
   add constraint FK_STOREING_STOREINGO_STOREING foreign key (StoreInGoodsStoreInOrderId, StoreInGoodsId)
      references StoreInGoods (StoreInOrderId, Id)
go

alter table StoreInGoodsWithVehicles
   add constraint FK_STOREING_STOREINGO_STOREING foreign key (StoreInGoodsVehicleId)
      references StoreInGoodsVehicle (Id)
go

alter table StoreInOrder
   add constraint FK_STOREINO_ASSOCIATI_CUSTOMER foreign key (CustomerId)
      references Customer (Id)
go

alter table StoreInUnitPrice
   add constraint FK_STOREINU_ASSOCIATI_STOREINO foreign key (StoreInOrderId)
      references StoreInOrder (Id)
go

alter table StoreOutCost
   add constraint FK_STOREOUT_ASSOCIATI_STOREOUT foreign key (StoreOutOrderId)
      references StoreOutOrder (Id)
go

alter table StoreOutGoods
   add constraint FK_STOREOUT_ASSOCIATI_GOODS foreign key (GoodsId)
      references Goods (Id)
go

alter table StoreOutGoods
   add constraint FK_STOREOUT_ASSOCIATI_STOREING foreign key (StoreInGoodsStoreInOrderId, StoreInGoodsId)
      references StoreInGoods (StoreInOrderId, Id)
go

alter table StoreOutGoods
   add constraint FK_STOREOUT_ASSOCIATI_STOREOUT foreign key (StoreOutOrderId)
      references StoreOutOrder (Id)
go

alter table StoreOutGoods
   add constraint FK_STOREOUT_ASSOCIATI_STOREINO foreign key (StoreInOrderId)
      references StoreInOrder (Id)
go

alter table StoreOutGoodsVehicle
   add constraint FK_STOREOUT_ASSOCIATI_VEHICLE foreign key (VehicleId)
      references Vehicle (Id)
go

alter table StoreOutGoodsWithVehicles
   add constraint FK_STOREOUT_STOREOUTG_STOREOUT foreign key (StoreOutGoodsStoreOutOrderId, StoreOutGoodsId)
      references StoreOutGoods (StoreOutOrderId, Id)
go

alter table StoreOutGoodsWithVehicles
   add constraint FK_STOREOUT_STOREOUTG_STOREOUT foreign key (StoreOutGoodsVehicleId)
      references StoreOutGoodsVehicle (Id)
go

alter table StoreOutOrder
   add constraint FK_STOREOUT_ASSOCIATI_STOREINU foreign key (StoreInUnitPriceStoreInOrderId)
      references StoreInUnitPrice (StoreInOrderId)
go

alter table StoreOutOrder
   add constraint FK_STOREOUT_ASSOCIATI_CUSTOMER foreign key (CustomerId)
      references Customer (Id)
go

alter table StoreOutUnitPrice
   add constraint FK_STOREOUT_ASSOCIATI_STOREOUT foreign key (StoreOutOrderId)
      references StoreOutOrder (Id)
go

