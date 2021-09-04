#!/bin/bash

docker run \
-e 'POSTGRES_USER=postgres' \
-e 'POSTGRES_PASSWORD=development' \
-e 'POSTGRES_DB=postgres' \
-p 5432:5432 \
-d \
--name "sangu" \
postgres:11-alpine

