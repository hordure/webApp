
ALTER TABLE  aspnetusers
ADD employee_eid INTEGER,
foreign key (employee_eid) references employee(eid);



