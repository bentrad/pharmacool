DROP TABLE SALES;
DROP TABLE PRODUCTS;


Create Table PRODUCTS(
	productid		int IDENTITY(1,1) PRIMARY KEY,
	pname			VARCHAR(30),
	pcost			DECIMAL(6,2),
	pstock			NUMERIC(6),
);

Create Table SALES(
	saleid			int IDENTITY(1,1) PRIMARY KEY,
	saledate		datetime,
	productid		int,
	qtysold			NUMERIC(4),
	saleprice		DECIMAL(6,2),
	FOREIGN KEY (productid) REFERENCES PRODUCTS,
	CONSTRAINT CHK_SALESTXN_saleprice
				CHECK ((saleprice >= 0) AND (saleprice <= 5000)),
	CONSTRAINT CHK_SALESTXN_qtysold
				CHECK ((qtysold >= 0) AND (qtysold <= 99)),
);
