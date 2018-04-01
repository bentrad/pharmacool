SELECT S.saleid "ID", S.saledate "Date", P.productid, P.pname "Description", S.qtysold "Quantity", S.saleprice "Per Item", SUM(S.qtysold*S.saleprice) AS "Total Price"
FROM SALES S
LEFT JOIN PRODUCTS P 
ON S.productid=P.productid
GROUP BY S.saleid, S.saledate, P.productid, P.pname, S.qtysold, S.saleprice
ORDER BY S.saleid;