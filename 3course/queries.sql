-- SELECT * FROM rooms
-- WHERE type_of_room_id = 2 AND id NOT IN (
--   SELECT room_id FROM booking 
--   WHERE ((date_of_end < '2023-05-03 00:00:00') OR
--   (date_of_start > '2023-05-03 00:00:00' AND
--   date_of_start > '2023-05-06 00:00:00'))
-- );

-- INSERT INTO ordered_services (booking_id, service_id) values (24, 4);

-- INSERT INTO tenants (full_name, phon_number) VALUES ("dodik", "24324242");

-- INSERT INTO booking (room_id, tenant_id, price_of_booking, date_of_start, date_of_end)
-- VALUES (2, 1, 400, '2023-05-07 00:00:00', '2023-05-10 00:00:00');

-- SELECT 
-- (CAST(julianday(b.date_of_end) - julianday(b.date_of_start) as INT)) * tr.price_per_day + 
-- SUM((CAST(julianday(b.date_of_end) - julianday(b.date_of_start) as INT)) * s.price_per_day) as total_price
-- from booking as b
-- INNER JOIN rooms as r ON r.id = b.room_id
-- INNER JOIN ordered_services as os ON os.booking_id = b.id 
-- INNER JOIN services as s ON s.id = os.service_id 
-- INNER JOIN types_of_room as tr ON tr.id = r.type_of_room_id 
-- WHERE b.id=24;

-- SELECT tenant_full_name from booking as b
-- INNER JOIN ordered_services as os ON os.booking_id = b.id 
-- GROUP BY b.id;

-- SELECT b.id, b.tenant_full_name, b.tenant_phone_number, 
-- r.number_of_room, t.type_title, t.room_area  
-- FROM Booking as b 
-- LEFT JOIN Rooms as r ON b.room_id = r.id 
-- LEFT JOIN types_of_room as t ON r.type_of_room_id = t.id; 

SELECT rooms.id as room_id, types_of_room.type_title, COUNT(booking.id) AS Number_of_bookings
FROM rooms
LEFT JOIN types_of_room ON rooms.type_of_room_id = types_of_room.id
LEFT JOIN booking ON Rooms.id = booking.room_id
GROUP BY type_title
ORDER BY rooms.Id ASC;