CREATE TABLE Employees
(
    Id UUID PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Title VARCHAR(50) NOT NULL
);

INSERT INTO Employees (Id, FirstName, LastName, Title)
VALUES
('d5c2d43c-adc6-4f68-a926-aa0f2231c57b', 'Jim', 'Jones', 'Developer'),
('945155a4-0cbf-4501-b3a0-baf8b90c481e', 'Sally', 'Smith', 'Development Manager'),
('12406bb3-c1fa-4569-b0d7-9c90ffa253ca', 'Tricia', 'Thompson', 'IT Director');

