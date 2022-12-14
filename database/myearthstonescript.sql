
/****** Object:  StoredProcedure [dbo].[SP_getAttributes]    Script Date: 9/4/2020 5:16:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[SP_getAttributes]
@CatID bigint,
@GroupID bigint
as


begin
select distinct alm.id_attribute,agl.id_attribute_group, agl.name as groupname, alm.name as attributename,at.position, (select count(distinct pl.name) from ps_product prod  inner  join ps_category_lang cat on prod.id_category_default = cat.id_category  inner  join ps_product_lang pl on prod.id_product = pl.id_product inner join ps_category_product catp on prod.id_product=catp.id_product inner join ps_product_attribute pa on prod.id_product=pa.id_product inner join ps_product_attribute_combination pac on pa.id_product_attribute=pac.id_product_attribute  inner join ps_attribute_lang al on pac.id_attribute=al.id_attribute inner join ps_attribute at on al.id_attribute=at.id_attribute inner join ps_attribute_group_lang agl on at.id_attribute_group=agl.id_attribute_group 

where cat.id_lang = 1  and pl.id_lang = 1 and prod.active = 1 and al.id_lang=1 and agl.id_lang=1 and catp.id_category=@CatID and al.id_attribute=alm.id_attribute) as coun from ps_product prod  inner join ps_category_product catp on prod.id_product=catp.id_product inner join ps_product_attribute pa on prod.id_product=pa.id_product inner join ps_product_attribute_combination pac on pa.id_product_attribute=pac.id_product_attribute  inner join ps_attribute_lang alm on pac.id_attribute=alm.id_attribute inner join ps_attribute at on alm.id_attribute=at.id_attribute inner join ps_attribute_group_lang agl on at.id_attribute_group=agl.id_attribute_group 

where catp.id_category=@CatID and agl.id_attribute_group=@GroupID  and prod.active = 1 and alm.id_lang=1 and agl.id_lang=1 order by at.position
end






















GO
/****** Object:  StoredProcedure [dbo].[SP_getAttributesItem]    Script Date: 9/4/2020 5:16:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE procedure [dbo].[SP_getAttributesItem]
@ProdID bigint,
@GroupID bigint

as


begin
select distinct alm.id_attribute,agl.id_attribute_group, agl.name as groupname, alm.name as attributename,at.position from ps_product prod  inner join ps_category_product catp on prod.id_product=catp.id_product inner join ps_product_attribute pa on prod.id_product=pa.id_product inner join ps_product_attribute_combination pac on pa.id_product_attribute=pac.id_product_attribute  inner join ps_attribute_lang alm on pac.id_attribute=alm.id_attribute inner join ps_attribute at on alm.id_attribute=at.id_attribute inner join ps_attribute_group_lang agl on at.id_attribute_group=agl.id_attribute_group 

where prod.id_product=@ProdID and agl.id_attribute_group=@GroupID  and prod.active = 1 and alm.id_lang=1 and agl.id_lang=1 order by at.position
end























GO
/****** Object:  StoredProcedure [dbo].[SP_getMainGroup]    Script Date: 9/4/2020 5:16:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[SP_getMainGroup]
@CatID bigint
as


begin
select distinct agl.id_attribute_group, agl.name as groupname,ag.position from ps_product prod  inner join ps_category_product catp on prod.id_product=catp.id_product inner join ps_product_attribute pa on prod.id_product=pa.id_product inner join ps_product_attribute_combination pac on pa.id_product_attribute=pac.id_product_attribute  inner join ps_attribute_lang al on pac.id_attribute=al.id_attribute inner join ps_attribute at on al.id_attribute=at.id_attribute inner join ps_attribute_group_lang agl on at.id_attribute_group=agl.id_attribute_group inner join ps_attribute_group ag on agl.id_attribute_group=ag.id_attribute_group where  catp.id_category=@CatID and prod.active = 1 and al.id_lang=1 and agl.id_lang=1 order by ag.position
end





















GO
/****** Object:  StoredProcedure [dbo].[SP_getMainGroupItem]    Script Date: 9/4/2020 5:16:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[SP_getMainGroupItem]
@ProdID bigint,
@Type nvarchar(50)
as


begin
select distinct agl.id_attribute_group, agl.name as groupname,ag.position,ag.group_type from ps_product prod  inner join ps_category_product catp on prod.id_product=catp.id_product inner join ps_product_attribute pa on prod.id_product=pa.id_product inner join ps_product_attribute_combination pac on pa.id_product_attribute=pac.id_product_attribute  inner join ps_attribute_lang al on pac.id_attribute=al.id_attribute inner join ps_attribute at on al.id_attribute=at.id_attribute inner join ps_attribute_group_lang agl on at.id_attribute_group=agl.id_attribute_group inner join ps_attribute_group ag on agl.id_attribute_group=ag.id_attribute_group where prod.active = 1 and al.id_lang=1 and agl.id_lang=1 and prod.id_product=@ProdID and ag.group_type=@Type and ag.id_attribute_group<>6 and ag.id_attribute_group<>7 order by ag.position
end






















GO
