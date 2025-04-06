
CREATE DATABASE  EventEase;
GO

-- Select the EventEase database
USE EventEase;
GO



-- Create the Venues table
CREATE TABLE Venues (
    VenueID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Location NVARCHAR(255) NOT NULL,
    Capacity INT NOT NULL,
    ImageUrl NVARCHAR(500) NULL -- Optional image URL
);
GO

-- Create the Events table with the foreign key to Venues

CREATE DATABASE  EventEase;
GO



-- Create the Venues table
CREATE TABLE Venues (
    VenueID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Location NVARCHAR(255) NOT NULL,
    Capacity INT NOT NULL,
    ImageUrl NVARCHAR(500) NULL -- Optional image URL
);
GO

-- Create the Events table with the foreign key to Venues
CREATE TABLE Events (
    EventID INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(100) NOT NULL,
    Date DATETIME NOT NULL,
    VenueID INT NOT NULL,

    CONSTRAINT FK_Events_Venues FOREIGN KEY (VenueID) REFERENCES Venues(VenueID) ON DELETE CASCADE
);
GO

-- Create the Bookings table with the foreign key to Events
CREATE TABLE Bookings (
    BookingID INT PRIMARY KEY IDENTITY(1,1),
    EventID INT NOT NULL,
    CustomerName NVARCHAR(100) NOT NULL,
    BookingDate DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Bookings_Events FOREIGN KEY (EventID) REFERENCES Events(EventID) ON DELETE CASCADE
);
GO

-- Insert Sample Data into Venues
INSERT INTO Venues (Name, Location, Capacity, ImageUrl) VALUES
('Grand Hall', '123 Main St, City Center', 500, 'https://via.placeholder.com/150'),
('Conference Room A', '456 Business Rd, Downtown', 200, 'https://via.placeholder.com/150'),
('Outdoor Amphitheater', '789 Park Ave, Suburbs', 1000, 'https://via.placeholder.com/150');
GO




-- Insert Sample Data into Bookings
INSERT INTO Bookings (EventID, CustomerName ) VALUES
(1, 'Alice Johnson'),
(2, 'Bob Smith'),
(3, 'Charlie Brown');
GO

SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Events';

INSERT INTO Events (Title, Date, VenueID,)
VALUES 
('Tech Conference', '2025-05-15 10:00:00', 1 , ),
('Music Festival', '2025-06-20 18:00:00', 3,),
('Business Seminar', '2025-07-10 14:00:00', 2,);
SELECT DB_NAME() AS CurrentDatabase;



UPDATE Venues
SET ImageUrl = 'https://example.com/venue-image.jpg'
WHERE VenueID = 1;
