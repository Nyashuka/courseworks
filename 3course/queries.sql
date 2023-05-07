SELECT * FROM rooms
WHERE type_of_room_id = 1 AND id NOT IN (
  SELECT room_id FROM booking 
  WHERE ((date_of_start < '2023-05-03 00:00:00' AND  
  date_of_end < '2023-05-03 00:00:00') OR
  (date_of_start > '2023-05-03 00:00:00' AND
  date_of_start > '2023-05-06 00:00:00'))
);

-- SELECT rooms.id, rooms.type_of_room_id, rooms.number_of_room FROM rooms 
-- INNER JOIN booking ON room_id = booking.room_id 
-- WHERE rooms.type_of_room_id = 1 AND 
-- (booking.room_id IS NULL OR 
-- (booking.date_of_start < '2023-05-03 00:00:00' AND  
-- booking.date_of_end < '2023-05-03 00:00:00') OR
-- booking.date_of_start > '2023-05-03 00:00:00' AND
-- booking.date_of_start > '2023-05-06 00:00:00');

-- SELECT rooms.id, rooms.type_of_room_id, rooms.number_of_room FROM rooms, booking
-- WHERE rooms.type_of_room_id = 1 AND 
-- ((booking.room_id IS NULL) OR 
-- (booking.room_id = rooms.id AND  
-- (booking.date_of_end < '2023-05-03 00:00:00' OR
-- (booking.date_of_start > '2023-05-03 00:00:00' AND
-- booking.date_of_start > '2023-05-16 00:00:00'))));



-- INSERT INTO tenants (full_name, phon_number) VALUES ("dodik", "24324242");

-- INSERT INTO booking (room_id, tenant_id, price_of_booking, date_of_start, date_of_end)
-- VALUES (2, 1, 400, '2023-05-07 00:00:00', '2023-05-10 00:00:00');