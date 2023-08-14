#bashCopy code
# Use the official Node.js image as the base image
FROM node:20

# Set the working directory in the container
WORKDIR /source

# Copy the application files into the working directory
COPY . /app

# Install the application dependencies
RUN npm install express
RUN npm install cookie-parser
RUN npm install ejs

EXPOSE 3000
# Define the entry point for the container
CMD ["node", "app"]