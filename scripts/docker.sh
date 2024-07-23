#!/bin/bash
docker_compose() {
    docker compose --env-file ./configs/.env -f ./docker/docker-compose.yml $@
}

start_container() {
    docker_compose up --build -d
}

build_container() {
    docker_compose build 
}

stop_container() {
    docker_compose down
}

exec_in_container() {
    docker_compose exec $1 "${@:2}"
}

case $1 in
    start | Start | START)
        start_container 
        ;;
    build | Build | BUILD)
            build_container 
            ;;
    stop | Stop | STOP)
        stop_container 
        ;;
    exec | Exec | EXEC)
        exec_in_container $2 "${@:3}"
        ;;
    *)
        echo "Comando inválido: $1. Use start, build, stop ou exec."
        exit 1
        ;;
esac