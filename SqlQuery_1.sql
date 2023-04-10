Update Abouts Set RoomCount = (Select Count(*) from Rooms),
StaffCount = (Select Count (*) From Staffs),
CustomerCount = (Select Count(*) from Guests)

Select * from Abouts

--Room tablosuna veri eklendikten sonra 1 artir
Create Trigger Roomincrease 
On Rooms
After Insert
As
Update Abouts Set RoomCount=RoomCount+1


--Room tablosuna veri eklendikten sonra 1 azalt
Create Trigger Roomdecrease 
On Rooms
After Delete
As
Update Abouts Set RoomCount=RoomCount-1

Create Trigger Staffincrease 
On Staffs
After Insert
As
Update Abouts Set StaffCount=StaffCount+1


Create Trigger Staffdecrease 
On Staffs
After Delete
As
Update Abouts Set StaffCount=StaffCount-1



Create Trigger Guestincrease 
On Guests
After Insert
As
Update Abouts Set CustomerCount=CustomerCount+1


Create Trigger Guestdecrease  
On Guests
After Delete
As
Update Abouts Set CustomerCount=CustomerCount-1
