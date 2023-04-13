@If not '%DEBUG%'=='TRUE' echo Off
TITLE Check current user drive mount

set SHARENAME=Depo
set DEPODRV=I:

:MAPDRIVE
IF NOT EXIST %DEPODRV% NET USE %DEPODRV% \\%COMPUTERNAME%\%SHARENAME% /PERSISTENT:YES

echo Finished
timeout /t 4

        