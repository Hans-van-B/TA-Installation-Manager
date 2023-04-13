@If not "%DEBUG%"=="TRUE" echo Off
TITLE Create Local Depo Share

set SHARE_DIR=C:\Data\Depo
set SHARENAME=Depo
set DEPODRV=I:

:CREATESHARE
if exist \\%COMPUTERNAME%\%SHARENAME% goto MAPDRIVE

if not exist "%SHARE_DIR%" md "%SHARE_DIR%"
if not exist "%SHARE_DIR%\TA_InstLib" md "%SHARE_DIR%\TA_InstLib"

NET LOCALGROUP TA_DEPO_Admin /ADD /COMMENT:"Provides Admin access to the TA Inst Depo"
NET LOCALGROUP TA_DEPO_Install /ADD /COMMENT:"Provides Read access to the TA Inst Depo for users that need to install software"

NET LOCALGROUP TA_DEPO_Admin Administrators /ADD
NET LOCALGROUP TA_DEPO_Admin %USERNAME% /ADD
NET LOCALGROUP TA_DEPO_Install %USERNAME% /ADD

NET SHARE %SHARENAME%="%SHARE_DIR%" /GRANT:TA_DEPO_Admin,FULL /GRANT:TA_DEPO_Install,READ /REMARK:"Technical Application Installation Share"

:MAPDRIVE
NET USE %DEPODRV% \\%COMPUTERNAME%\%SHARENAME% /PERSISTENT:YES

echo Finished
timeout /t 10
