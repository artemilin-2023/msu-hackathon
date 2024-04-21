build:
	docker compose --file ./cicd/docker-compose.yml build

up: start
run: start
start: stop
	docker compose --file ./cicd/docker-compose.yml up --detach

down: stop
stop:
	docker compose --file ./cicd/docker-compose.yml --file ./cicd/docker-compose.tailscale.yml down


dev:
	docker compose --file ./cicd/docker-compose.yml --file ./cicd/docker-compose.tailscale.yml up tailscale-sidecar --detach
devdown:
	docker compose --file ./cicd/docker-compose.yml --file ./cicd/docker-compose.tailscale.yml down tailscale-sidecar


logs:
	docker compose --file ./cicd/docker-compose.yml --file ./cicd/docker-compose.tailscale.yml logs -f

configure:
	cd backend && python3.11 -m venv venv
	cd backend && source ./venv/bin/activate && pip install -r requirements.dev.txt -r requirements.txt
	cd frontend && npm install

format:
	cd backend && source ./venv/bin/activate && autoflake -r --in-place --remove-all-unused-imports ./my_app_api
	cd backend && source ./venv/bin/activate && isort ./my_app_api
	cd backend && source ./venv/bin/activate && black ./my_app_api
	cd frontend && npm run lint
	cd frontend && npm run format
	cd frontend && npm run stylelint
