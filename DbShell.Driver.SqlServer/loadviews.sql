﻿SELECT o.name as [Name], u.name as [Schema] FROM sys.objects o INNER JOIN sys.schemas u ON u.schema_id=o.schema_id WHERE type in ('V')