alter table "Federation" add "refreecount" smallint

create or replace function "leaguecount"()
returns trigger
as
$$ 
begin
update "League" set teamcount=teamcount+1 from "Team" where "League"."LeagueID"= public."Team"."LeagueID";
return new;
end;
$$ 
language 'plpgsql';

create trigger "tr_leaguecount"
after insert
on public."Team"
for each row
execute procedure "leaguecount"()


create or replace function "deleteleaguecount"()
returns trigger
as
$$
begin
update "League" set teamcount=teamcount-1 from "Team" where "League"."LeagueID" = "Team"."LeagueID";
return new;
end;
$$
language 'plpgsql';

create trigger "tr_deleteleagecount"
after delete on public."Team"
for each row
execute procedure "deleteleaguecount"()

create or replace function "plusrefreecount"()
returns trigger
as
$$ 
begin
update "Federation" set refreecount=refreecount+1 from "Refree" where "Federation"."FedID"= public."Refree"."FedID";
return new;
end;
$$ 
language 'plpgsql';

create trigger "tr_leaguecount"
after insert
on public."Refree"
for each row
execute procedure "plusrefreecount"()

create or replace function "deletefedcount"()
returns trigger
as
$$
begin
update "Federation" set refreecount=refreecount-1 from "Refree" where "Federation"."FedID" = public."Refree"."FedID";
return new;
end;
$$
language 'plpgsql';

create trigger "tr_deletefedcount"
after delete on public."Refree"
for each row
execute procedure "deletefedcount"()


create function "totalteam"()
returns int
language plpgsql
as
$$
declare
   goalkeeper_count integer;
begin
   select count(*) 
   into goalkeeper_count
   from "Goalkeeper";
 
   return goalkeeper_count;
end;
$$;

create function "totaldefence"()
returns int
language plpgsql
as
$$
declare
   defence_count integer;
begin
   select count(*) 
   into defence_count
   from "Defence";
 
   return defence_count;
end;
$$;

create function "totalmidfielder"()
returns int
language plpgsql
as
$$
declare
   midfielder_count integer;
begin
   select count(*) 
   into midfielder_count
   from "Midfielder";
 
   return midfielder_count;
end;
$$;

create function "totalforward"()
returns int
language plpgsql
as
$$
declare
   forward_count integer;
begin
   select count(*) 
   into forward_count
   from "Forward";
 
   return forward_count;
end;
$$;