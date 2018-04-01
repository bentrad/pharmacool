PRINT 'Adding Test Data to Product Table';

INSERT INTO PRODUCTS(pname, pcost, pstock)
	VALUES('Nurofen',12.95,100);

INSERT INTO PRODUCTS(pname, pcost, pstock)
	VALUES('COLDNFLU',19.95,50);

PRINT 'Adding Test Data to Sales Table';

INSERT INTO SALES(saledate, productid, qtysold, saleprice)
	VALUES('2018-02-01T09:15:00',1,2,12.95);

INSERT INTO SALES(saledate, productid, qtysold, saleprice)
	VALUES('2018-02-05T10:15:00',2,5,19.95);
