# Simple-AI
Simple Conversational Artificial Intelligence for Video Games
##Concept
The basic concept is to be able to create game characters that players can talk to by typing instead of picking preset dialogue options.

The system does use preset dialogues currently, but it has the functionality to decide what inputs can be considered equivalent, and then
respond accordingly.

For example, let's say I wanted players to be able to ask my character, `"who is bob?"` and get the response, `"Bob is the king of Bobania!"`.
The players, when playing, might actually ask something like, `"can you tell me who bob is?"`, or `"I want to know who bob is."` 
In those cases, Simple-AI will determine that those phrases are equivalent to asing `"who is bob?"`, and will respond with, `"Bob is the king
of Bobania!"`, as it should.
##Workflow
The workflow for this github project is as follows (code given works on Windows):

1. Contributors clone the repository to their local machine, and work on it locally: `git clone https://github.com/wilkesreid/Simple-AI`, then `cd Simple-AI`
2. They checkout the `development` branch, and commit to that.
3. When they want to push a commit to github, they push it to `development`.
4. Every so often, the owner will merge the `development` branch to the `review` branch, where the changes can be discussed.
5. The owner, and select contributors, will modify the code in the `review` branch to make sure it's ready for release.
6. The owner will merge the review branch to the `master` branch.

Because this is the work flow for this project, contributors should ONLY commit and push to the `development` branch, NOT the `review` or `master` branch.

The `gh-pages` branch is just web code for wilkesreid.github.io/Simple-AI. That should be left alone.
