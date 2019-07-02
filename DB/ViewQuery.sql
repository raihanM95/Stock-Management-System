CREATE VIEW StocksView
AS
SELECT Stocks.ID, Stocks.ItemID, Stocks.Quantity, Stocks.Date, Stocks.Status, Items.ItemName 
FROM Stocks LEFT OUTER JOIN Items ON Stocks.ItemID = Items.ID



SELECT * FROM StocksView ORDER BY Date DESC