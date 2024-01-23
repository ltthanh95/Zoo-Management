CREATE DEFINER = CURRENT_USER TRIGGER `Team10`.`Private_Event_Purchase_BEFORE_INSERT` BEFORE INSERT ON `Private_Event_Purchase` FOR EACH ROW
BEGIN
	DECLARE maxAttending BIGINT;
	DECLARE booked TINYINT;
	DECLARE attending BIGINT;

	SET attending := (SELECT COUNT(*) # Count number of attendees
		FROM Team10.Private_Event_Purchase
		WHERE EVENT_ID=NEW.Event_ID);
	SET maxAttending := (SELECT Guest_Capacity # Grab capacity, and booked status for event
		FROM Team10.Private_Event
		WHERE Event_ID = NEW.Event_ID
		LIMIT 1);
	SET booked := (SELECT Is_Booked # Grab capacity, and booked status for event
		FROM Team10.Private_Event
		WHERE Event_ID = NEW.Event_ID
		LIMIT 1);

	IF (booked)
			OR
			(attending) >= (maxAttending) THEN
		# Incase is booked status wasn't set already
		UPDATE `Team10`.`Private_Event`
				SET
				`Is_Booked` = 1
				WHERE `Event_ID` = NEW.Event_ID;
		# error, event capacity reached
		SIGNAL SQLSTATE '45000'
		SET MESSAGE_TEXT = 'That event capacity is full.';
	END IF;
	IF (attending + 1) >= (maxAttending) then
		# Reached capacity, setting booked status. All good to insert
		UPDATE `Team10`.`Private_Event`
				SET
				`Is_Booked` = 1
				WHERE `Event_ID` = NEW.Event_ID;
	END IF;
	
END;