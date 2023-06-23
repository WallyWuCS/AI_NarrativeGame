# AI_NarrativeGame
A narrative game designed through OpenAI API

# Initialization
To use the OpenAI API, you need to use your own API key. You can create one through https://platform.openai.com/account/api-keys. To use your key:
Add a file to the path ~/.openai/auth.json (Linux/Mac) or %USERPROFILE%/.openai/auth.json (Windows)

if you only have an API key, the auth.json should look like this

``
{
  "api_key":"<YOUR_KEY>"
}
``
If you have an organization key, the auth.json should look like this

``
{
  "api_key":"<YOUR_KEY>",
  "organization":"<YOUR_ORGANIZATION_ID>"
}
``
