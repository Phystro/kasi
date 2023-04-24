#!/bin/bash

# Set the migration path
MIGRATIONS_PATH="./Persistence/Migrations/"
STARTUP_PROJECT="../Presentation/Web/Server/Kasi.Web.Server.csproj"

while getopts ":a:r" opt; do
  case $opt in
    a)
      NAME="$OPTARG"
      echo "Adding migration: $NAME"
      echo ""

      dotnet ef migrations add $NAME -o $MIGRATIONS_PATH --startup-project $STARTUP_PROJECT
      # ls -alh $MIGRATIONS_PATH

      echo ""
      echo "DONE"
      echo ""

      echo "Updating database"
      echo ""

      # ls -alh $STARTUP_PROJECT
      dotnet ef database update --startup-project $STARTUP_PROJECT

      echo ""
      echo "DONE"
      ;;
    r)
      echo "Deleting migration"
      echo ""

      # Add code for deletion command here
      echo "DELETION HERE"
      rm -rfv $MIGRATIONS_PATH
      # ls -alh $MIGRATIONS_PATH

      echo ""
      echo "DONE"
      ;;
    \?)
      echo "Invalid option: -$OPTARG" >&2
      exit 1
      ;;
    :)
      case $OPTARG in
        a)
          echo "Option -$OPTARG requires an argument for migration name." >&2
          exit 1
          ;;
        *)
          echo "Invalid option: -$OPTARG" >&2
          exit 1
          ;;
      esac
      ;;
    *)
      echo "Invalid option: -$OPTARG" >&2
      exit 1
      ;;
  esac
done

# Check if -a or -r options are provided
if [[ $OPTIND -eq 1 ]]; then
  echo "Please provide either -a option with a migration name or -r option for deletion." >&2
  exit 1
fi

