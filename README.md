Some ideas of how this should work

Server (HTTP interface, sends MQ jobs to clients)
- Store jobs
- Run scheduler, emit job messages on trigger

Client (Listens on MQ, executes jobs)
- Keep local job package cache
- Execute jobs
- Send new jobs to the server
- Shouldn't need to emit any messages?  Only should need to listen for messages from the server for distrubuted task execution


Example Use Cases

Weekly Database Update:
1. Every friday some client (server w/scheduler) emits message to update database
2. Clients that are subscribed to this job receive message
3. Clients receiving job message ask the server for the latest job with the id from the message
4. Server returns job package
5. Clients execute

Triggered Database Update:
1. Client asks server for latest job with given id
2. Server returns job package
3. Client executes
