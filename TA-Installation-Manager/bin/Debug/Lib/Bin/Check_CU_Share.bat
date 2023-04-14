@call %~dp0Init
TITLE Check current user drive mount

if not exist %LocalShare% (
  echo Warning: The local share does not exist.
  echo          or you need to logout and login first.
  pause
  exit
  )

if exist %DEPODRV%\TA_InstLib (
  echo Warning: The local depo drive %DEPODRV% already exists
  pause
  exit
  )

if exist %DEPODRV%\. (
  echo Warning: The local drive %DEPODRV% already exists
  echo          but it may be used for another network location.
  pause
  exit
  )

:MAPDRIVE
IF NOT EXIST %DEPODRV% NET USE %DEPODRV% %LocalShare% /PERSISTENT:YES

echo Finished
timeout /t 4

        