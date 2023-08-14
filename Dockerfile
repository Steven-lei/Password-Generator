#bashCopy code
# Use the official Node.js image as the base image
FROM node:20

# Set the working directory in the container
WORKDIR /

# Copy the application files into the working directory
COPY . .

# Install the application dependencies

EXPOSE 80
# Define the entry point for the container
CMD ["node", "app.js"]