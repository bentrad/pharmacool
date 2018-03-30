DROP TABLE PRODUCT;
DROP TABLE INVENTORY;
DROP TABLE SALESTXNS;


Create Table PRODUCT(
	productid		Number(8),
	pname			Varchar2(30),
	pcost			Number(6,2),
	CONSTRAINT PK_PRODUCT PRIMARY KEY (productid)
);

Create Table INVENTORY(
	invid			Number(8),
	productid		Number(8),
	quantity		Number(6),
	CONSTRAINT PK_INV PRIMARY KEY (invid),
	FOREIGN KEY (productid) REFERENCES PRODUCT
);

Create Table SALESTXN(
	txnid			Number(8),
	saledate		datetime,
	productid		Number(8),
	qtysold			Number(4),
	saleprice		Number(6,2),
	Primary Key (txnid),
	CONSTRAINT PK_SALESTXN PRIMARY KEY (txnid),
	FOREIGN KEY (productid) REFERENCES PRODUCT,
	CONSTRAINT CHK_SALESTXN_saleprice
				CHECK ((saleprice >= 0) AND (saleprice <= 5000)),
	CONSTRAINT CHK_SALESTXN_qtysold
				CHECK ((qtysold >= 0) AND (qtysold <= 99)),
);
