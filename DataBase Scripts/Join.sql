use Zoo_2;

select * from especie;
select * from country;

select e.nombre_vul, c.nombre from especie e, country c;

select e.nombre_vul as nombre_vulgar, c.nombre as país from especie e, country c
where e.origen = c.id_country;

select 
e.nombre_vul as nombre_vulgar,
c.nombre as país 
from especie e join country c
on e.origen = c.id_country;

select 
e.nombre_vul as nombre_vulgar,
c.nombre as país 
from especie e left join country c
on e.origen = c.id_country;

select
a.nombre as nombre_animal,
e.nombre_vul as nombre_vulgar,
e.nombre_cien as nombre_cientifico,
c.nombre as pais
from animal a left join especie e
on a.especie = e.id_especie left join country c
on e.origen = c.id_country;

select * from especie;
select * from animal;
select * from country;