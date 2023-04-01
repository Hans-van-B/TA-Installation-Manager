@If not "%DEBUG%"=="TRUE" echo Off
TITLE Undo Local Depo Share and settings

set SHARE_DIR=C:\Data\Depo
set SHARENAME=Depo
set DEPODRV=I:

NET USE %DEPODRV% /D
NET SHARE %SHARENAME% /D

NET LOCALGROUP TA_DEPO_Admin /DELETE
NET LOCALGROUP TA_DEPO_Install /DELETE

if not exist "%SHARE_DIR%" goto END

set /p RSP=Also delete %SHARE_DIR% [y/N] ? ^>
if /i "%RSP%"=="Y" rd /s /q "%SHARE_DIR%"

:END
echo Finished
timeout /t 10
        