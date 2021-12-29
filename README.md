# GameJolt GameAPI
c# .net Core wrapper for the Game Jolt Game API

## Current version
The current version of the Game Jolt Game API is 1.2.

## Classes
These are the features currently supported by the API:

| Class | Description |
|---|---|
| DataStore | Manipulate items in a cloud-based data storage. |
| Time | Get the server's time. |
| Scores | Manipulate scores on score tables. |
| Sessions | Set up sessions for your game. |
| Trophies | Manage trophies for your game. |
| Users | Access user-based features. |
| Friends | List a user's friends. |
| Batch | Merge multiple API calls into one request. |

## Getting Started
ToDo: setting things up to use the API

---
## DataStore
A cloud-based data storage system. It's completely up to you what you use this for. The more inventive the better!

### Methods
| Name | Description |
|---|---|
| Fetch | Fetches data from the data store. |
| Get keys | Fetches keys of data items from the data store. |
| Remove | Removes data items from the data store. |
| Set | Sets data in the data store. |
| Update | Updates data in the data store with various functions. |

### Example uses
* Global game statistics
* User-specific statistics
* In-game messaging system
* User-generated content hosting (e.g level packs)
* Asynchronous Turn-Based Strategy Games
* Instant Replay System

### Remarks
Data storage is limited to 16MB per key.

 ---
## Time
A namespace to obtain time information from the Game Jolt server.

### Methods
| Name | Description |
|---|---|
|Time Fetch | Fetches the time from the server. |

### Example Uses
* Realize real-time gameplay for everyone playing the same game
* Security systems based on the server time

---
## Scores
Game Jolt supports multiple online score tables, or scoreboards, per game. You are able to, for example, have a score table for each level in your game, or a table for different scoring metrics. Gamers will keep coming back to try to achieve the highest scores for your game.

With multiple formatting and sorting options, the system is quite flexible. You are also able to include extra data with each score. If there is other data associated with the score such as time played, coins collected, etc., you should definitely include it. It will be helpful in cases where you believe a gamer has illegitimately achieved a high score.

### Methods
| Name | Description |
|---|---|
| Add | Adds a score. |
| Get Rank | Gets a rank for a specific score. |
| Fetch | Fetches scores from a score table. |
| Tables | Fetches a list of score tables. |

### Example Uses
* Highscore tables for each level of a game.
* Global ranking list for all players.

### Remarks
Extra data you include is not shown anywhere on the site, and you are limited only by your own imagination!

---
## Sessions
Sessions are used to tell Game Jolt when a user is playing a game, and what state they are in while playing (active or idle).

### Methods
| Name | Description |
|---|---|
| Open | Opens a session. |
| Ping | Pings a session. |
| Check | Checks if a session is open. |
| Close | Closes a session. |

### Example Uses
* Get a list of players that are currently playing your game.
* Let others know whether a player is idle or not.

### Remarks
Sessions are currently only shown to other users in Public Chat. In the near future, this data will become more visible on the site. For example:

* Sessions will be shown as live to friends.
* Gamers will be able to see which games they (and their friends) have played and for how long.
* Developers will be able to see the total play time of their games.

---
## Trophies
Game Jolt allows you to add trophies to your games!

Trophies come in four materials: bronze, silver, gold, and platinum. This is to reflect how difficult it is to achieve a trophy. A bronze trophy should be easy to achieve, whereas a platinum trophy should be very hard to achieve.

On Game Jolt, trophies are always listed in order from easiest to most difficult to achieve.

You can also tag trophies on the site as "secret". A sercet trophy's image and description is not visible until a gamer has achieved it.

### Methods
| Name | Description |
|---|---|
| Fetch | Fetches trophies with various attributes. |
| Add Achieved | Add a trophy to a user's list of achieved trophies. |
| Remove Achieved | Removes an achieved trophy. |

### Remarks
You can manage trophies for your game from your game's dashboard.

---
## Users
Your games will not authenticate users by using their username and password. Instead, users have a token to verify themselves along with their username.

Passing in the username and token can sometimes interrupt the flow of your game, so Game Jolt makes the effort to automatically pass your game the username and token whenever possible.

* Java Applets are automatically passed the the username and token in Applet Parameters.
* Flash games are automatically passed the username and token in flashvars.
* It works similarly with Unity Webplayer and Silverlight games.
* Downloadable games running through the Game Jolt Client are passed the username and token in an automatically generated file: `.gj-credentials`, placed next to the game's executable. Definitely check that out!

### Methods
| Name | Description |
|---|---|
| Auth | Verfies a username-token combination. |
| Fetch | Fetches user information. |

### Example Uses
* Display users' profiles in your game.
* Let the user log in and use other services with their username-token combination.

### Remarks
Usernames only contain alphanumeric characters, hyphens, and underscores.

---
## Friends
A namespace to get information about users friends on Game Jolt

### Methods
| Name | Description |
|---|---|
| Friends | Lists a user's friends. |

### Example Uses
* List and count friends.
* Find currently online friends.

---
## Batch
A batch request is a collection of sub-requests that enables developers to send multiple API calls with one HTTP request.

When you construct the URL for a batch request, it can become quite long. Because of this, you can send the request via POST data instead of GET. However, you're also free to pass it as a GET request.

### Remarks
* The maximum amount of sub requests in one batch request is 50.
* Dump format is not supported in batch calls.
* The parallel and break_on_error parameters cannot be used in the same request.
* For more information on how to use the batch request, visit the Construction page.

---