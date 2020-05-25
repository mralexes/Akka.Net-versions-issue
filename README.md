Tested versions: Akka 1.3.18, Akka 1.4.6

# Repro run:

1. Clone the repo
2. Run: `docker-compose build`
3. Run: `docker-compose up -d`
4. Run: `docker stats` and check containers CPU usage
