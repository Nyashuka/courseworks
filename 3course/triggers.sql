-- create trigger before_delete_type_of_room
-- before delete on types_of_room
-- begin
--   delete from rooms where type_of_room_id = OLD.id;
-- end;

-- create trigger before_delete_room
-- before delete on rooms
-- begin
--   delete from booking where room_id = OLD.id;
-- end;

-- create trigger before_delete_booking
-- before delete on booking
-- begin
--   delete from booking_addition_information where booking_id = OLD.id;
--   delete from ordered_services where booking_id = OLD.id;
-- end;

-- DROP TRIGGER "main"."before_delete_employee";
-- CREATE TRIGGER before_delete_employee
-- BEFORE DELETE on employees
-- BEGIN
-- UPDATE services set employee_id = NULL 
-- WHERE employee_id = OLD.id;
-- END;

