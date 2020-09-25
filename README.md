# Start by using this repository as a fork

Start by [forking this repo](https://github.com/netbrain/github-workflow-kata/fork)

# Game of life 

This Kata is about calculating the next generation of [Conway’s game of life](http://en.wikipedia.org/wiki/Conway%27s_Game_of_Life), given any starting position

You start with a two dimensional grid of cells, where each cell is either alive or dead. In this version of the problem, the grid is finite, and no life can exist off the edges. 
When calcuating the next generation of the grid, follow these rules:

1. Any live cell with fewer than two live neighbours dies, as if caused by underpopulation.
2. Any live cell with more than three live neighbours dies, as if by overcrowding.
3. Any live cell with two or three live neighbours lives on to the next generation.
4. Any dead cell with exactly three live neighbours becomes a live cell.

You should write a program that can accept an arbitrary grid of cells, and will output a similar grid showing the next generation.

## Input's and outputs

The program should accept the following as input:

```
Generation 1:
4 8
........
....*...
...**...
........
```

And then produce the resulting output:

```
Generation 2:
4 8
........
...**...
...**...
........
```

## Project setup
Start by creating a project board (under the tab `Projects`) with the template `Automated kanban board with review` in this repository

Then configure the repo correctly by setting up main/master as a protected branch. 

`(Settings -> Branches -> Add rule)`

And set the following rules:

Branch name pattern: `main`

- [x] Require pull request reviews before merging
    - [x] Dismiss stale pull request approvals when new commits are pushed
    - [x] Require review from Code Owners
    - [ ] Restrict who can dismiss pull request reviews
- [x] Require status checks to pass before merging
    - [x] Require branches to be up to date before merging
- [ ] Require signed commits
- [x] Require linear history
- [x] Require pull request reviews before merging
- [x] Include administrators
- [ ] Restrict who can push to matching branches
- [ ] Allow force pushes
- [ ] Allow deletions

## Do work
For this setup you require one or more review buddies.

You can use whatever programming language you would like for this task. If you crave an extra challenge then try to use a TDD approach to this. And if you want to you can also add a github action for your programming language of choosing. A good starting point would be the `Continuous integration workflows
` delivered by github.

First order of business would be to create a new github issue, something along the lines of `initial project structure`, as well as the aforementioned requirements. I would suggest using userstories, e.g. `As a live cell I will die if I have fewer than two live neighbours`

When you have written down all requirements as issues you can proceed to do some actual work. (remember to attach issues to the project board you created)

So let's get started with something simple, lets create the initial project structure.

```
# clone the remote repository
git clone <insert path to your fork here> game-of-life
# change the current working directory
cd game-of-life
# checkout the main branch 
git checkout main
# check status for branch
git status
# get latest from upstream        
git pull                   
# create a new feature branch based on the latest upstream
git checkout -b feature-1   # 1 here should match the issue id you are working on
```
̈́
Now you should set up the initial project structure: here are some quickstarts you can use.

**Java**

```
mvn archetype:generate \
    -DgroupId=game-of-life \
    -DartifactId=game-of-life \
    -DarchetypeArtifactId=maven-archetype-quickstart
```

**.NET Core**

`dotnet new console -n game-of-life`


**NodeJS**

```
npm init
echo '#!/usr/bin/env node' >> index.js
echo 'console.log("Hello world!");' >> index.js
chmod +x index.js
./index.js
```

When you have settled on a programming language and project structure, then continue with committing your changes to the remote repo.

```
# check status for branch
git status  # this should yield a bunch of new untracked files
# add all the changes
git add .
# check status again
git status  # should yield a correct list of changes to be comitted
# commit changes
git commit -m "initial project layout, resolves #1"
# push changes to remote
git push
```

This should work fine, and if you read the returned output from the push command you should see something about creating a new PR. Click on that link and create the suggested pull request.

This is when you need to invite your buddy to review your change. If the review fails, you need to checkout the offending branch, and do some more work as per the reviewers suggestions. and then re-commit and re-push.

If the reviewer approves your changes, then congratulations, you have come full circle. Next up would be to rinse and repeat for every issue in your backlog. Good luck, have fun!

Remember to follow along with the project board as youn make changes and iterate over issues and PR's.
