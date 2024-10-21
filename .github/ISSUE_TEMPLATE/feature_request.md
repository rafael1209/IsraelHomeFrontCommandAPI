---
name: Feature request
about: Suggest an idea for this project
title: ''
labels: ''
assignees: ''

---

name: Feature request
description: Suggest a new feature or improvement
title: "[FEATURE] Your feature title"
labels: enhancement
assignees: ''

body:
  - type: markdown
    attributes:
      value: "Help us improve the project by suggesting a new feature."

  - type: input
    id: feature
    attributes:
      label: Feature Name
      description: "Provide a short name for the feature."
      placeholder: "Feature name"

  - type: textarea
    id: motivation
    attributes:
      label: Motivation
      description: "Why do you want this feature? What problem does it solve?"
      placeholder: "Explain why this feature is needed"

  - type: textarea
    id: solution
    attributes:
      label: Proposed Solution
      description: "Describe how you imagine this feature would work."
      placeholder: "Describe your solution"

  - type: textarea
    id: alternatives
    attributes:
      label: Alternatives
      description: "Have you considered any alternative solutions?"
      placeholder: "List any alternatives here"
