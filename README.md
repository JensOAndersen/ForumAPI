# Creating an API As an excercise

Creating this api, along with its frontend counterpart: https://github.com/JensOAndersen/ForumApp, has been an interesting experience.

What i've learned about:
  * JSON Web Tokens, how they're generated, what info is stored in them, and what i can use them for
  * An introduction to authentication, right now the only thing you need to sign into the API and get a token, is a hardcoded username, not secure at all, but as i was looking into it i stumbled upon the field of cryptography and decided that it wasnt time for that yet.
  * How not to design an API, making routes like api/posts/1/comments/1 doesnt make any sense, and should probably not ever exist.
  * Using DTO's, sending the pure model as an API result is not desireable, you'll end up sending way too much data, and you dont have any control over what data is sent.
    * In the future i'll use a library for handling DTO's, or look up on how its done manually, the way i've done it here is a mess.
  * Handling CORS, appareantly postman and localhost is not the same
  
What i could do better:
  * Authentication, authentication, authentication
    * In the future i'll use a vendor to create logins, though making my own login system might be a fun challenge one day.
  * Planning the API before i begin programming, what routes makes sense, and what doesnt.
  * Unit tests, i know how to make them, but i dont know how to unit test an API, there's also something strange with DTO's here (maybe)
  
All in all, a fun project, feel free to fork and inspect it.

For the next project i'll probably start with the backend, make everything work, then begin constructing the frontend.
