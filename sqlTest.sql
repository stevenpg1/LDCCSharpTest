SELECT b.Business, ISNULL(p.StreetNo,'') as StreetNo, p.Street, p.PostCode, sum(f.Count) as FootfallCount 
FROM Businesses b 
INNER JOIN Premises p ON b.Id = p.BusinessId
INNER JOIN Footfall f ON p.Id = f.PremisesId
GROUP BY b.Business, ISNULL(p.StreetNo,''), p.Street, p.PostCode