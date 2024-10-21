---
name: Bug report
about: Create a report to help us improve
title: ''
labels: ''
assignees: ''

---

name: Bug report
description: Report a bug or issue with the project
title: "[BUG] Your bug title"
labels: bug
assignees: ''

body:
  - type: markdown
    attributes:
      value: "Please provide detailed information about the issue."

  - type: input
    id: os
    attributes:
      label: Operating System
      description: "What OS and version are you using?"
      placeholder: "e.g., Windows 10, macOS Monterey"

  - type: input
    id: version
    attributes:
      label: Version
      description: "What version of the project are you using?"
      placeholder: "e.g., 5.1.0"

  - type: textarea
    id: description
    attributes:
      label: Description
      description: "Please describe the issue in detail."
      placeholder: "Describe the problem here"

  - type: textarea
    id: steps
    attributes:
      label: Steps to Reproduce
      description: "List the steps to reproduce the issue."
      placeholder: "1. Step one\n2. Step two\n3. Step three"

  - type: textarea
    id: expected
    attributes:
      label: Expected Behavior
      description: "What did you expect to happen?"
      placeholder: "Expected result"

  - type: textarea
    id: actual
    attributes:
      label: Actual Behavior
      description: "What actually happened?"
      placeholder: "Actual result"

  - type: input
    id: screenshots
    attributes:
      label: Screenshots or Logs
      description: "Provide any relevant screenshots or logs if applicable."
      placeholder: "Link to screenshot or log"
