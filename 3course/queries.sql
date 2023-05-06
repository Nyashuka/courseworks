SELECT rooms.id, rooms.type_of_room_id, rooms.number_of_room FROM rooms 
LEFT JOIN booking ON room_id = booking.room_id 
WHERE rooms.type_of_room_id = 3 AND 
(booking.room_id IS NULL OR 
(booking.date_of_start < '2023-05-03 00:00:00' AND  
booking.date_of_end < '2023-05-03 00:00:00') OR
booking.date_of_start > '2023-05-03 00:00:00' AND
booking.date_of_start > '2023-05-06 00:00:00');

-- INSERT INTO tenants (full_name, phon_number) VALUES ("dodik", "24324242");

-- INSERT INTO booking (room_id, tenant_id, price_of_booking, date_of_start, date_of_end)
-- VALUES (2, 1, 400, '2023-05-07 00:00:00', '2023-05-10 00:00:00');