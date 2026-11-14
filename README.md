<div align="right">
  <a href="#magyar">Magyar</a> | <a href="#english">English</a>
</div>

<a name="english"></a>

# C# WinForms Telemetry & Hardware Monitors

Two .NET Framework (WinForms) desktop monitoring projects featuring real-time chart visualization, local status persistence, and parameterized MySQL database storage.

### Solutions Included

1. **`LedStatusMonitor/`** (`20_grafika.sln`)
   - Interactive hardware LED state controller and graphical toggle UI (`ledon.png` / `ledoff.png`), recording state transitions to `status.txt` and plotting timeline updates via `System.Windows.Forms.DataVisualization.Charting`.
2. **`TemperatureMySqlLogger/`** (`SQL.sln`)
   - Live simulated temperature monitor (`Form1.cs`) paired with `MySQLHelper.cs` using `Devart.Data.MySql` and parameterized SQL queries (`INSERT INTO adatok (Homerseklet) VALUES (@temperature)`), querying the last hour's series directly into a WinForms line chart.

### Configuration
- Open the desired `.sln` file in Visual Studio (.NET Framework 4.7.2).
- In `TemperatureMySqlLogger/SQL/MySQLHelper.cs`, update the connection string credentials (`User ID` / `Password`) and ensure your MySQL database contains the `adatok` table before running.

---

<a name="magyar"></a>

# C# WinForms Telemetria- és Állapotmonitor Alkalmazások

Két .NET Framework (WinForms) alapú asztali monitorozó alkalmazás valós idejű grafikonos megjelenítéssel, helyi állapotnaplózással és paraméterezett MySQL adatbázis-kezeléssel.

### Tartalom

1. **`LedStatusMonitor/`** (`20_grafika.sln`)
   - Grafikus LED állapotvezérlő és idősoros monitorozó alkalmazás (`ledon.png` / `ledoff.png`), amely a kapcsolási eseményeket a `status.txt` fájlban naplózza és `DataVisualization.Charting` grafikonon ábrázolja.
2. **`TemperatureMySqlLogger/`** (`SQL.sln`)
   - Valós idejű hőmérséklet-naplózó alkalmazás (`Form1.cs`) és adatbázis-réteg (`MySQLHelper.cs`), amely `Devart.Data.MySql` segítségével, paraméterezett SQL lekérdezéssel menti (`INSERT INTO adatok (Homerseklet) VALUES (@temperature)`) és jeleníti meg vonaldiagramon az elmúlt egy óra adatait.

### Beállítás
- Nyisd meg a kiválasztott `.sln` fájlt Visual Studio-ban (.NET Framework 4.7.2).
- A `TemperatureMySqlLogger/SQL/MySQLHelper.cs` fájlban állítsd be a saját MySQL kapcsolati adataidat, és hozd létre az `adatok` táblát futtatás előtt.
