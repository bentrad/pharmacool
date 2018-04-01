DROP TABLE PRODUCT;
DROP TABLE INVENTORY;
DROP TABLE SALESTXNS;


Create Table PRODUCT(
	productid		NUMERIC(8),
	pname			VARCHAR(30),
	pcost			DECIMAL(6,2),
	CONSTRAINT PK_PRODUCT PRIMARY KEY (productid)
);

Create Table INVENTORY(
	invid			NUMERIC(8),
	productid		NUMERIC(8),
	quantity		NUMERIC(6),
	CONSTRAINT PK_INV PRIMARY KEY (invid),
	FOREIGN KEY (productid) REFERENCES PRODUCT
);

Create Table SALESTXN(
	txnid			NUMERIC(8),
	saledate		datetime,
	productid		NUMERIC(8),
	qtysold			NUMERIC(4),
	saleprice		DECIMAL(6,2),
	CONSTRAINT PK_SALESTXN PRIMARY KEY (txnid),
	FOREIGN KEY (productid) REFERENCES PRODUCT,
	CONSTRAINT CHK_SALESTXN_saleprice
				CHECK ((saleprice >= 0) AND (saleprice <= 5000)),
	CONSTRAINT CHK_SALESTXN_qtysold
				CHECK ((qtysold >= 0) AND (qtysold <= 99)),
);
