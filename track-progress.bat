@echo off
echo AIpointment Progress Tracker
echo ==========================
echo.
echo This script helps you track progress in the COMBINED_TASK_PLAN.md file.
echo.
echo To mark a task as complete, manually edit the file and change the checkbox:
echo    ⬜ (not started) to 🟡 (in progress) or ✅ (completed)
echo.
echo Current status of main milestones:
echo.

find /c "⬜ Lesson" "TASK_PLAN.md"
echo Not started lessons
echo.

find /c "🟡 Lesson" "COMBINED_TASK_PLAN.md"
echo In progress lessons
echo.

find /c "✅ Lesson" "COMBINED_TASK_PLAN.md"
echo Completed lessons
echo.

echo For more detailed tracking, open COMBINED_TASK_PLAN.md in your editor.