 ***AppResolution*** 
- Finds all of the main processes running on your system and hold info relating to each process.
- Currently the only main info is the dimension of the process.


**Documentation for DllImport**
- FindWindow(string lpszClass, string lpszWindow) can be found here: http://www.pinvoke.net/default.aspx/user32.findwindow
- GetWindowRect(IntPtr hwnd, out WindowDimension.RECT lpRect) can be found here: https://www.pinvoke.net/default.aspx/user32.getwindowrect
- Code for RECT struct can be found here: http://www.pinvoke.net/default.aspx/Structures/RECT.html


GetAppInfo() will return a Dictionary<string name, Resoultion> of all main proccess running.
- To get the name of an app access the AppResolution.Key property that GetAppInfo returns.
- To get the height or width of an app access the AppResolution.Value.Width or AppResolution.Value.Height


*Feel free to use and add additional properties that are useful.* 
